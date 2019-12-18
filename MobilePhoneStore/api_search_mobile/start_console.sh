#!/usr/bin/env bash
CWD="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

VIR="$(. ./venv/bin/activate)"

start_stop=$1
shift

case $start_stop in
     (start)
         nohup python run_console.py digital_sale_marketing_console < /dev/null > nohub.out 2>&1
     (stop)
         kill -9 `pgrep -f digital_sale_marketing_console`
esac
