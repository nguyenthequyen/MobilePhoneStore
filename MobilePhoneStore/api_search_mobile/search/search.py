import json

import requests
from flask import Blueprint, render_template, request
from config.config import Config
from exception.exception import CustomException


elasticsearch_url = Config.config["elasticsearch_url"]
index_name = Config.config["index_name"]

# creating a Blueprint class
search_blueprint = Blueprint('search',__name__,template_folder="templates")
search_term = ""


headers = {
    'Content-Type': "application/json",
    'cache-control': "no-cache",
}

def search_products():
    payload = {
      "query": {
        "multi_match": {
          "query": "4000 mAh",
          "fields": ["pin"]
        }
      }
    }
    url = elasticsearch_url + "/product/_search"
    payload = json.dumps(payload)
    response = requests.request('GET', url, data=payload, headers=headers)
    response_dict_data = json.loads(str(response.text))
    return json.dumps(response_dict_data)

def add_product(object):
    url = elasticsearch_url + "/product/"
    payload = json.dumps(object)
    response = requests.request('POST', url, data=payload, headers=headers)
    response_dict_data = json.loads(str(response.text))
    return response_dict_data

def delete_product(object):

    if "id" not in object or object["id"] == "" or object["id"] is None:
        raise CustomException('product_id is not exist, can not delete product', 400)
    else:
        payload = {
            "query": {
                "term": {
                    "id": object["id"]
                }
            }
        }
        payload = json.dumps(payload)
        url = elasticsearch_url + "/product/_delete_by_query"
        response = requests.request('DELETE', url, data=payload, headers=headers)
        response_dict_data = json.loads(str(response))
        return response_dict_data

def update_product(obectt):

    if "id" not in object or object["id"] == "" or object["id"] is None:
        raise CustomException('product_id is not exist, can not update product', 400)
    else:
        payload = {
            "query": {
                "term": {
                    "id": object["id"]
                }
            }
        }
        payload = json.dumps(payload)
        url = elasticsearch_url + "/product/_update_by_query?conflicts=proceed"
        response = requests.request('POST', url, data=payload, headers=headers)
        response_dict_data = json.loads(str(response))
        return response_dict_data


def get_product_by_term(object):

    if "term" not in object:
        raise CustomException('product_id is not exist, can not update product', 400)
    else:
        payload = {
            "query": {
                "term": {
                    object["term"]: object["value"]
                }
            }
        }
        payload = json.dumps(payload)
        url = elasticsearch_url + "/product/"
        response = requests.request('GET', url, data=payload, headers=headers)
        response_dict_data = json.loads(str(response.text))
        return response_dict_data
"""
@search_blueprint.route("/",methods=['GET','POST'],endpoint='index')
def index():
    if request.method=='GET':
        res ={
	            'hits': {'total': 0, 'hits': []}
             }
        return render_template("index.html",res=res)
    elif request.method =='POST':
        if request.method == 'POST':
            print("-----------------Calling search Result----------")
            search_term = request.form["input"]
            print("Search Term:", search_term)
            payload = {
                "query": {
                    "query_string": {
                        "analyze_wildcard": True,
                        "query": str(search_term),
                        "fields": ["topic", "title", "url", "labels"]
                    }
                },
                "size": 50,
                "sort": [

                ]
            }
            payload = json.dumps(payload)
            url = "http://elasticsearch:9200/hacker/tutorials/_search"
            response = requests.request("GET", url, data=payload, headers=headers)
            response_dict_data = json.loads(str(response.text))
            return render_template('index.html', res=response_dict_data)


@search_blueprint.route("/autocomplete",methods=['POST'],endpoint='autocomplete')
def autocomplete():
    if request.method == 'POST':
        search_term = request.form["input"]
        print("POST request called")
        print(search_term)
        payload ={
          "autocomplete" : {
            "text" : str(search_term),
            "completion" : {
              "field" : "title_suggest"
            }
          }
        }
        payload = json.dumps(payload)
        url="http://elasticsearch:9200/autocomplete/_suggest"
        response = requests.request("GET", url, data=payload, headers=headers)
        response_dict_data = json.loads(str(response.text))
        return json.dumps(response_dict_data)"""



