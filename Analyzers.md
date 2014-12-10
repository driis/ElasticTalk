Analyzers
---
We can create an index with a mapping. Show analyzed/not analyzed with the examples.
```
DELETE /x
PUT /x
{
    "mappings": {
        "foo":{
            "properties": {
                "bar": {
                    "type": "string",
                    "index": "analyzed"
                }
            }
        }
    }
}
GET /x/_mapping

PUT /x/foo/1
{
    "bar":"Acme-Stuff"
}

PUT /x/foo/2
{
    "bar":"The quick brown fox"
}
```

#### Query examples
```
GET /x/foo/1
GET /x/foo/_search?q=bar:acme
GET /x/foo/_search?q=bar:acme stuff
GET /x/foo/_search?q=bar:acme-stuff
GET /x/foo/_search?q=bar:Acme-Stuff
GET /x/foo/_search?q=bar:brown fox
```

#### Using the analyzer API
How would the text be indexed in the field bar using current mapping ?
```
GET /x/_analyze?field=bar&text=Acme-Stuff
GET /x/_analyze?field=bar&text=Acme stuff
```

Given an analyzer, how would it analyze the given text ?
```
GET /_analyze?analyzer=english&text=The quick brown fox jumped over

GET _analyze?analyzer=standard&text=Set the shape to semi-transparent by calling set_trans(5)

GET _analyze?analyzer=simple&text=Set the shape to semi-transparent by calling set_trans(5)

GET _analyze?analyzer=whitespace&text=Set the shape to semi-transparent by calling set_trans(5)

GET _analyze?analyzer=english&text=Set the shape to semi-transparent by calling set_trans(5)
```
