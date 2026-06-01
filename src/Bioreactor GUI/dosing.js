const broker = "wss://public.cloud.shiftr.io";
const requester = new XMLHttpRequest();
const databaseURL = "http://127.0.0.1:8000/getConfig";
const m1DoseSelector = document.getElementById("motor1MlPerMinute");
const m2DoseSelector = document.getElementById("motor2MlPerMinute");
const m3DoseSelector = document.getElementById("motor3MlPerMinute");
const currMls1 = document.getElementById("ml1");
const currMls2 = document.getElementById("ml2");
const currMls3 = document.getElementById("ml3");
let ML1 = 0;
let ML2 = 0;
let ML3 = 0;

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
  ML1 = datah[1];
  ML2 = datah[2];
  ML3 = datah[3];
  currMls1.innerHTML = ML1;
  currMls2.innerHTML = ML2;
  currMls3.innerHTML = ML3;
}

let client = mqtt.connect(broker, options);
client.on("connect", () => {
  console.log("amconnect");
});

function updateConfig() {
  await fetch(databaseURL, {
    method: "POST", body: `{"motor1MlPerMinute":"${ML1}", "motor2MlPerMinute":"${ML2}", "motor3MlPerMinute":"${ML3}"}`
  });
}

m1DoseSelector.addEventListener("change", (event) => {
  let m1Dosage = parseFloat(m1DoseSelector.value) * 10;
  client.publish("BioreactorGui/dosingSchedulingM1", m1Dosage.toString(), options);
  updateConfig();

});
m2DoseSelector.addEventListener("change", (event) => {
  let m2Dosage = parseFloat(m2DoseSelector.value) * 10;
  client.publish("BioreactorGui/dosingSchedulingM2", m2Dosage.toString(), options);
  updateConfig();
});
m3DoseSelector.addEventListener("change", (event) => {
  let m3Dosage = parseFloat(m3DoseSelector.value) * 10;
  client.publish("BioreactorGui/dosingSchedulingM3", m3Dosage.toString(), options);
  updateConfig();
});
setInterval(updateDosingLabels, 1000);