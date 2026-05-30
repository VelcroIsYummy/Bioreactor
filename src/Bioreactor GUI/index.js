const broker = "wss://public.cloud.shiftr.io";
const requester = new XMLHttpRequest();
const databaseURL = "http://127.0.0.1:8000";
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
  }
);


const temper = document.getElementById("tempChart");
const rpmer = document.getElementById("rpmChart");
const doser = document.getElementById("dosingChart");
const oder = document.getElementById("od600Chart");
const chartOptions = {
    maintainAspectRatio: false,
    backgroundColor: "#548dff",
    color: "#eed1b0",
    responsive: true,
    scales: {
      y: {
        beginAtZero: true,
      },
  },
  },


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
  options: chartOptions,
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
  options: chartOptions,
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
  options: chartOptions,
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


// TODO: add constantly updating aria labels so you can screen read the graphs. Also add dosing