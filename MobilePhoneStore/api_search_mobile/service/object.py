import json

def error_msg(msg, code):
    return {
        "error_message" : msg,
        "code" : code,
        "status": False
    }

def success_msg(data, code):
    return {
        "message": "Success",
        "code": code,
        "data": data
    }

class Object:
    @staticmethod
    def convert_json(json_str):
        response = json.loads(json_str)
        list_objects = response["hits"]["hits"]
        results = []
        if len(list_objects) == 0:
            return json.dumps(error_msg("Data is empty", 200))
        for obj in list_objects:
            product = obj["_source"]
            results.append(product)

        return success_msg(results, 200)
