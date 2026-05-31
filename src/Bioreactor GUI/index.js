const broker = "wss://public.cloud.shiftr.io";
const requester = new XMLHttpRequest();
const databaseURL = "http://127.0.0.1:8000";
const tempBox = document.getElementById("tempSelector");
const rpmBox = document.getElementById("rpmSelector");
const motorKpBox = document.getElementById("motorKpSelector");
const motorKiBox = document.getElementById("motorKiSelector");
const motorKdBox = document.getElementById("motorKdSelector");
const heaterKpBox = document.getElementById("heaterKpSelector");
const heaterKiBox = document.getElementById("heaterKiSelector");
const heaterKdBox = document.getElementById("heaterKdSelector");
Chart.defaults.backgroundColor = '#ffffff';
Chart.defaults.borderColor = '#ffffff';
Chart.defaults.color = '#FFFFFF';
let options = {
  clean: true,
  connectTimeout: 10000,
  clientId: "mqttJsClient-" + Math.floor(Math.random() * 1000000),
  username: "public",
  password: "public",
};

function addDataToAnyChart(chart, label, data) {
  chart.data.labels.push(label);
  chart.data.datasets.forEach((dataset) => {
    dataset.data.push(data);
  });
  chart.update();
}

tempBox.addEventListener("change", (event) => {
  client.publish("BioreactorGui/heaterSetpoint", tempBox.value, options);
  console.log(tempBox.value);
});
rpmBox.addEventListener("change", (event) => {
  client.publish("BioreactorGui/rpmSetpoint", rpmBox.value, options);
});
motorKpBox.addEventListener("change", (event) => {
  client.publish("BioreactorGui/rpmKp", motorKpBox.value, options);
});
motorKiBox.addEventListener("change", (event) => {
  client.publish("BioreactorGui/rpmKi", motorKiBox.value, options);
});
motorKdBox.addEventListener("change", (event) => {
  client.publish("BioreactorGui/rpmKd", motorKdBox.value, options);
});
heaterKpBox.addEventListener("change", (event) => {
  client.publish("BioreactorGui/heaterKp", heaterKpBox.value, options);
});
heaterKiBox.addEventListener("change", (event) => {
  client.publish("BioreactorGui/heaterKi", heaterKiBox.value, options);
});
heaterKdBox.addEventListener("change", (event) => {
  client.publish("BioreactorGui/heaterKd", heaterKdBox.value, options);
});

requester.onload = () => {
  if (xhr.readyState === xhr.DONE) {
    console.log(xhr.response);
    console.log(xhr.responseText);
  }
};

requester.open("GET", databaseURL);
requester.responseType = "text";
let databaseData = requester.responseText;
console.log(databaseData);
let datah = Papa.parse(databaseData);
datah = datah["data"];
console.log(datah, {
  header: true,
  dynamicTyping: true,
});

const temper = document.getElementById("tempChart");
const rpmer = document.getElementById("rpmChart");
const doser = document.getElementById("dosingChart");
const oder = document.getElementById("od600Chart");

tempChart = new Chart(temper, {
  type: "line",
  data: {
    labels: [],
    datasets: [
      {
        label: "Bioreactor Temprature",
        data: [],
        borderWidth: 1,
      },
    ],
  },
  options: {
    maintainAspectRatio: false,
    backgroundColor: "#ED2939",
    color: "#FFFFFF",

    responsive: true,
    scales: {
      y: {
        beginAtZero: true,
      },
    },
  },
});

rpmChart = new Chart(rpmer, {
  type: "line",
  data: {
    labels: [],
    datasets: [
      {
        label: "Motor RPM",
        data: [],
        borderWidth: 1,
      },
    ],
  },
  options: {
    maintainAspectRatio: false,
    backgroundColor: "#3F704D",
    color: "#FFFFFF",

    responsive: true,
    scales: {
      y: {
        beginAtZero: true,
      },
    },
  },
});

od600Chart = new Chart(oder, {
  type: "line",
  data: {
    labels: [],
    datasets: [
      {
        label: "OD600",
        data: [],
        borderWidth: 1,
      },
    ],
  },
  options: {
    maintainAspectRatio: false,
    backgroundColor: "#548dff",
    color: "#FFFFFF",

    responsive: true,
    scales: {
      y: {
        beginAtZero: true,
      },
    },
  },
});

datah.forEach((element) => {
  addDataToAnyChart(tempChart, parseFloat(element[4]), parseFloat(element[0]));
  addDataToAnyChart(rpmChart, parseFloat(element[4]), parseFloat(element[2]));
  addDataToAnyChart(od600Chart, parseFloat(element[4]), parseFloat(element[4]));
});

let client = mqtt.connect(broker, options);
client.on("connect", () => {
  console.log("amconnect");
});

function checkIfDatabaseUpdate() {
  requester.open("GET", databaseURL);
  let databaseData = requester.responseText;
  if (datah != Papa.parse(databaseData)) {
    element = datah.at(-1);
    addDataToAnyChart(tempChart, element[4], element[0]);
    addDataToAnyChart(rpmChart, element[4], element[2]);
    addDataToAnyChart(od600Chart, element[4], element[4]);
  }
}

setInterval(checkIfDatabaseUpdate, 1000);