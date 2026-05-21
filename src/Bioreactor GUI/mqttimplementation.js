const broker = "wss://public.cloud.shiftr.io";
let options = {
  clean: true,
  connectTimeout: 10000,
  clientId: "mqttJsClient-" + Math.floor(Math.random() * 1000000),
  username: "public",
  password: "public",
};
let temprature = 0;
let motorRpm = 0;
let quantityOfMessagesRecived = 0;
let dosesGiven = 0;

function addDataToAnyChart(chart, label, data) {
  chart.data.labels.push(label);
  chart.data.datasets.forEach((dataset) => {
    dataset.data.push(data);
  });
  chart.update();
}

function onRecivedTempratureData(temprature) {
  addDataToAnyChart(tempChart, quantityOfMessagesRecived, temprature);
  document.getElementById("currentRpmTextLabel").innerHTML = `Temprature: ${temprature}°C`;
}


function onRecivedMotorData(motorRpm) {
  addDataToAnyChart(rpmChart, quantityOfMessagesRecived, motorRpm);
  document.getElementById("currentRpmTextLabel").innerHTML = `RPM: ${motorRpm}RPM`;
}

const temper = document.getElementById("tempChart");
const rpmer = document.getElementById("rpmChart");
const doser = document.getElementById("dosingChart");
const oder = document.getElementById("od600Chart");

Chart.defaults.font.family = "Geist";
Chart.defaults.font.weight = 600;
Chart.defaults.backgroundColor = "#ff5454";
Chart.defaults.borderColor = "#eed1b0";
Chart.defaults.color = "#eed1b0";
tempChart = new Chart(temper, {
  type: "line",
  data: {
    labels: [1],
    datasets: [
      {
        label: "Bioreactor Temprature",
        data: [0],
        borderWidth: 1,
      },
    ],
  },
  options: {
    maintainAspectRatio: false,
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
    labels: [1],
    datasets: [
      {
        label: "Motor RPM",
        data: [0],
        borderWidth: 1,
      },
    ],
  },
  options: {
    backgroundColor: "#548dff",
    maintainAspectRatio: false,
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
    labels: [1],
    datasets: [
      {
        label: "OD600",
        data: [0],
        borderWidth: 1,
      },
    ],
  },
  options: {
    backgroundColor: "#d754ff",
    maintainAspectRatio: false,
    responsive: true,
    scales: {
      y: {
        beginAtZero: true,
      },
    },
  },
});

let client = mqtt.connect(broker, options);
client.on("connect", () => {
  client.subscribe("Bioreactor/ThermocoupleTemprature");
  client.subscribe("Bioreactor/MotorRpm");
  console.log("amconnect");
});

client.on("message", (topic, message, packet) => {
  if (topic == "Bioreactor/ThermocoupleTemprature") {
    temprature = parseFloat(message);
    onRecivedTempratureData(temprature);
  }
  if (topic == "Bioreactor/MotorRpm") {
    motorRpm = parseFloat(message);
    onRecivedMotorData(motorRpm);
  }
  quantityOfMessagesRecived++;
});

// TODO: add constantly updating aria labels so you can screen read the graphs. Also add dosing