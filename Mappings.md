# Mappings

Mappings are deduced when a type is first encountered

```
PUT /map/numeric/1
{
    "n": "1",
    "foo":"bar"
}

PUT /map/numeric_stuff/1
{
    "n": 32,
    "foo":"bar"
}
```

Even when the mapping is implicit, type constraints apply.
You will get an error when types don't match:

```
PUT /map/numeric_stuff/2
{
    "n": "foobar",
    "foo":"bar"
}
```

It's easy to get the mapping for a type:

```
GET /map/_mapping/numeric
GET /map/_mapping/numeric_stuff
```

And to add or change one explicitly:
```
PUT /map/_mapping/numeric
{
    "properties":{
        "n":{"type":"long"}
    }
}
```

Any type can have 0 to more values. This is expressed by a JSON array.
```
PUT /map/numeric_stuff/4
{
  "x": ["me", "tes"]
}
```



Obviously, we should specify the mapping when creating the index
```
PUT /gb
{
  "mappings": {
    "tweet" : {
      "properties" : {
        "tweet" : {
          "type" :    "string",
          "analyzer": "english"
          },
          "date" : {
            "type" :   "date"
            },
            "name" : {
              "type" :   "string"
              },
              "user_id" : {
                "type" :   "long"
              }
            }
          }
        }
    }
      ```
