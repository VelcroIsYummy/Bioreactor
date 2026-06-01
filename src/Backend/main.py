from fastapi import FastAPI
from fastapi import Request
import time
import hashlib

api = FastAPI();

@api.get("/getConfig")
async def requestConfig():
  with open("config.csv") as config:
    return config.read();

@api.post("/updateConfig")
async def updateDb(request: Request):
  data = await request.json();
  sha256 = hashlib.sha256();
  apiKey = "d34f3c6446b3c6250b5be1042f078049629c2c5ffb682bab73c89812f3240390";
  if "key" in data:
    sha256.update(data["key"].encode("UTF-8"));
  else:
    return 401;
  recivedKey = sha256.hexdigest();
  if recivedKey == apiKey:
    try:
      with open("config.csv", "w") as config:
        dm1 = data["motor1MlPerMinute"];
        dm2 = data["motor1MlPerMinute"];
        dm3 = data["motor3MlPerMinute"];
        config.write(f"{dm1}, {dm2}, {dm3}");
        return 200;
    except:
      return 401;

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
  if recivedKey == apiKey:
    try:
      with open("database.csv", "a") as database:
        temp = data["temperature"];
        pH = data["pH"];
        rpm = data["rpm"];
        od600 = data["od600"];
        database.write(f"{temp}, {pH}, {rpm}, {od600}, {time.time()}\n");
        return 200;
    except:
      return 401;