# ElasticSearch talk notes

### Put in some data

```
PUT /employees/employee/5
{
    "name":"Mick Testguy",
    "age": 47,
    "interests": ["rock music","climbing"]
}
```
Puts the JSON document into the `employees` index, use type `employee` and assign id `5`.

### Simple query string
#### Search all indexes for "john in any field"
```
GET /_search?q=john
```

#### Search for "john" in email:
```
GET /_search?q=email:john
```

#### Query DSL
```
POST /employees/employee/_search
{
    "query": {
        "match": {
           "name": "John"
        }
    }
    , "filter": {
        "range": {
           "age": {
              "to": 40
           }
        }
    }
}
```

#### Aggregations
```
POST shakespeare/line/_search?search_type=count
{
  "aggs":{
    "types":{
      "terms": {
        "field":"speaker"
      }
    }
  }
}


POST shakespeare/line/_search
{
  "filter":{
    "term":{
      "speaker":"BRUTUS"
    }
    },
    "aggs":{
      "plays":{
        "terms":{
          "field":"play_name"
        }
      }
    }
  }
```
