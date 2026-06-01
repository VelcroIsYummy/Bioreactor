const broker = "wss://public.cloud.shiftr.io";
const requester = new XMLHttpRequest();
const databaseURL = "http://127.0.0.1:8000/getConfig";
const m1DoseSelector = document.getElementById("motor1MlPerMinute");
const m2DoseSelector = document.getElementById("motor2MlPerMinute");
const m3DoseSelector = document.getElementById("motor3MlPerMinute");
const currMls1 = document.getElementById("ml1");
const currMls2 = document.getElementById("ml2");
const currMls3 = document.getElementById("ml3");

let options = {
  clean: true,
  connectTimeout: 10000,
  clientId: "mqttJsClient-" + Math.floor(Math.random() * 1000000),
  username: "public",
  password: "public",
};

function updateDosingLabels() {
  requester.open("GET", databaseURL);
  requester.responseType = "text";
  let databaseData = requester.responseText;
  console.log(databaseData);
  let datah = Papa.parse(databaseData);
  datah = datah["data"];
  currMls1.innerHTML = datah[1];
  currMls1.innerHTML = datah[2];
  currMls1.innerHTML = datah[3];
}

let client = mqtt.connect(broker, options);
client.on("connect", () => {
  console.log("amconnect");
});

m1DoseSelector.addEventListener("change", (event) => {
  let m1Dosage = parseFloat(m1DoseSelector.value) * 10;
  client.publish("BioreactorGui/dosingSchedulingM1", m1Dosage.toString(), options);
});
m2DoseSelector.addEventListener("change", (event) => {
  let m2Dosage = parseFloat(m2DoseSelector.value) * 10;
  client.publish("BioreactorGui/dosingSchedulingM2", m2Dosage.toString(), options);
});
m3DoseSelector.addEventListener("change", (event) => {
  let m3Dosage = parseFloat(m3DoseSelector.value) * 10;
  client.publish("BioreactorGui/dosingSchedulingM3", m3Dosage.toString(), options);
});
setInterval(updateDosingLabels, 1000);