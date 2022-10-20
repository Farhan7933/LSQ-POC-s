import elasticsearch
from elasticsearch import Elasticsearch
import elasticsearch_dsl
from elasticsearch_dsl import Search
import psycopg2

# create an elasticsearch object.
es = Elasticsearch(["localhost"],http_auth=("elastic", "changeme"),port="9200")
# connect to PostgreSQL and create a cursor object.

conn = psycopg2.connect(host="localhost", database="UsersDB", user="postgres", password= "Post123$greS")
cur = conn.cursor()

# Get the required data from the documents.
s = Search(index= "users").using(es).query("match_all")
es_result= s.execute()

# Load the data into a list.
subscriber_list = []
for x in es_result:
    subscriber_list.append((x.name, x.age, x.address))

# Load the list into a PostgreSQL table using the INSERT statement and close the connection.
query = "INSERT INTO users(name, age, address) VALUES (%s, %s, %s)"
cur.executemany(query, subscriber_list)
conn.commit()
conn.close()