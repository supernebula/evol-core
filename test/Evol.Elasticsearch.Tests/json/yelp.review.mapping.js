// curl -XPOST localhost:9200/twiiter/review -d

{
    "settings":{
        "number_of_shards" : 5, //分片数5
        "number_of_replicas" : 1 //副本数量1
    },

    "mappings": {
        "properties": {
            "id":    {
                "type": "keyword",
                    "index": "not_analyzed", //不分析，原始值编入索引
                        "store": "yes"
            }, 
            "stars": { "type": "integer" },
            "date":     {
                "type": "date",
                    "format": "strict_date_optional_time||epoch_millis",

                },
            "text":     { "type": "text", },
            "useful":     { "type": "integer" },
            "funny":     { "type": "integer" },
            "cool":     { "type": "integer" },
            "business_id":      { "type": "keyword" }, 
            "user_id":      { "type": "keyword" }
        }
    }
}