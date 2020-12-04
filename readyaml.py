import yaml
schema_text = '''
    name:
        type:string
    age:
        type:integer
        min:10
    '''
schema = yaml.load(schema_text)
document = {'name': 'Little Joe', 'age': 5}
v.validate(document,schema)
v.errors