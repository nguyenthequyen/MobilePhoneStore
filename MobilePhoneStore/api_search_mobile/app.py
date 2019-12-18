from flask import Flask, jsonify, make_response, request
import search.search as search
from service.object import Object as obj
from exception.exception import CustomException

app = Flask(__name__)


@app.errorhandler(404)
def not_found(error):
    return make_response(jsonify({'message': 'Page not found', 'code': 404}), 404)

@app.errorhandler(400)
def bad_request(error):
    return make_response(jsonify({'message': str(error), 'code': 400}), 400)

@app.errorhandler(500)
def bad_request(error):
    return make_response(jsonify({'message': str(error), 'code': 500}), 500)

@app.errorhandler(CustomException)
def handle_invalid_usage(error):
    response = jsonify(error.to_dict())
    response.status_code = error.status_code
    return response


@app.route('/api/v1/products', methods=['GET', 'POST'])
def product():
    json = search.search_products()
    results = obj.convert_json(json)
    return jsonify(results)

@app.route('/api/v1/add/product', methods=['POST'])
def add_product():
    if not request.json:
        raise CustomException('Product data is invalid of json type', 400)
    response = search.add_product(request.json)
    return jsonify(response)

@app.route('/api/v1/delete/product', methods=['DELETE', 'POST'])
def delete_product():
    if not request.json:
        raise CustomException('Product data is invalid of json type', 400)

    response = search.delete_product(request.json)
    return jsonify(response)

@app.route('/api/v1/update/product', methods=['PUT', 'POST'])
def update_product():
    if not request.json:
        raise CustomException('Product data is invalid of json type', 400)

    response = search.update_product(request.json)
    return jsonify(response)

@app.route('/api/v1/get/product', methods=['GET', 'POST'])
def get_product():
    object = {}
    if request.method == 'GET':
        object["term"] = request.args.get('term')
        object["value"] = request.args.get('value')
        return jsonify(search.get_product_by_term(object), 200)
    elif request.method == 'POST':
        if not request.json:
            raise CustomException('Product data is invalid of json type', 400)
        return jsonify(search.get_product_by_term(request.json), 200)

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=8080)
