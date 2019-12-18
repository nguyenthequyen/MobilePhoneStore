#!/usr/bin/env bash
CWD="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

# START vars
LOG_FILE="$CWD/log.log"
NUM_WORKER=3
PORT=5000
TIMEOUT=120
APP_WSGI=wsgi:app
OUTPUT=nohup.out
API_PID=API_PID
export APP_SETTINGS=ProductionConfig
# END vars

# virtualenv
DIR_ENV="./$(ls | grep env)"
echo "activate virtualenv at $DIR_ENV"
. ./$DIR_ENV/bin/activate
echo "python::$(which python)"

# START functions declare
function usage {
	echo "$(basename $0), params: [$(echo $LIST_FUNCS)]"
}

function log {
    echo "`date`  $1" | tee -a $LOG_FILE
}

function check {
  ps -aux | grep gunicorn | grep $APP_WSGI
}

function install {
  python -m pip install -r requirements.txt
}

function start {
  gunicorn \
    --workers=$NUM_WORKER \
    --bind=0.0.0.0:$PORT \
    --timeout=$TIMEOUT \
    --log-level=DEBUG \
    --capture-output \
    --access-logfile=logs/access.log \
    --error-logfile=logs/error.log \
    --daemon \
    --config=gunicorn_conf.py \
    $APP_WSGI

  # console
  start_console

  if [[ ! "$?" -eq "0" ]]; then
    echo 'error'
    tail error.log
  else
    echo 'started'
    check
  fi
}

function stop {
  check | awk '{print $2}' | xargs -L1 kill -9

  stop console
}

function restart {
  stop
  sleep 2
  start
}

# console
function start_console {
  #!/usr/bin/env bash
  echo "console is redirected to /dev/null"
  nohup python run_console.py digital_sale_marketing_console 2>&1 > /dev/null # no output
}

function stop_console {
  kill -9 `pgrep -f digital_sale_marketing_console`
}

# define custom functions here

LIST_FUNCS=$(declare -F | cut -d ' ' -f3 | sed 's/usage\|log//')
# END functions declare

# main body
case $# in
	1)  # i just need one parmas
		if [[ -n "`echo $LIST_FUNCS | xargs -n1 echo | grep -e \"^$1$\"`" ]]; then
			echo "'$1' match"
			echo "run \`$1\`"
			type $1
			$1
		else
			echo "'$1' not match"
			usage
		fi
		;;
	*)
		usage
		;;
esac
