from fastapi import FastAPI
from fastapi import Request
import time
import hashlib

api = FastAPI();

@api.get("/reciveTheEntireDatabase")
async def requestDb():
  with open("database.csv") as database:
    return database.read();

@api.post("/updateTheEntireDatabase")
async def updateDb(request: Request):
  data = await request.json();
  sha256 = hashlib.sha256();
  apiKey = "d34f3c6446b3c6250b5be1042f078049629c2c5ffb682bab73c89812f3240390";
  if "key" in data:
    sha256.update(data["key"].encode("UTF-8"));
  else:
    return 401;
  recivedKey = sha256.hexdigest();
  print(recivedKey)
  if recivedKey != apiKey:
    try:
      with open("database.csv", "a") as database:
        temp = data["temperature"];
        pH = data["pH"];
        rpm = data["rpm"];
        od600 = data["od600"];
        time = time.time()
        database.write(f"{temp}, {pH}, {rpm}, {od600}, {time}\n");
    except:
      return 401;
  return 200;

