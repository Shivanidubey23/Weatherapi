document.getElementById("currentLocationButton").addEventListener("click", function () {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(fetchCurrentLocationWeather);
    } else {
        alert("Geolocation is not supported by this browser.");
    }
});

document.getElementById("searchButton").addEventListener("click", function () {
    var location = document.getElementById("locationInput").value;
    fetchWeather(location);
    fetchForecast(location);
});

document.getElementById("searchButton").addEventListener("click", function () {
    var locationInput = document.getElementById("locationInput").value.trim();
    if (locationInput === "") {
        alert("Please enter a location.");
    } else {
        // Proceed with search functionality
    }
});



function fetchCurrentLocationWeather(position) {
    var latitude = position.coords.latitude;
    var longitude = position.coords.longitude;
    fetch(`https://api.openweathermap.org/data/2.5/weather?lat=${latitude}&lon=${longitude}&appid=c30126dea994df88110129cd4db5189d`)
        .then(response => response.json())
        .then(data => {
            var city = data.name; // Extract city name from response
            displayWeather(data, city); // Pass city name along with data
            updatePlaceholder(city); // Update location input placeholder
            // Call fetchWeather with city name and coordinates
            fetchWeather(city, latitude, longitude);
            // Call fetch5DayForecast with latitude and longitude
            // Call fetch5DayForecast with latitude and longitude
            fetch5DayForecast(latitude, longitude);
        })
        .catch(error => console.error('Error:', error));
}

function fetchWeather(location) {
    fetch(`https://api.openweathermap.org/data/2.5/weather?q=${location}&appid=c30126dea994df88110129cd4db5189d`)
        .then(response => response.json())
        .then(data => {
            console.log(data); // Log the response to inspect it
            displayWeather(data, location); // Call the displayWeather function with the data and location name
            // Extract latitude and longitude for the entered city
            var latitude = data.coord.lat;
            var longitude = data.coord.lon;
            // Call fetchAQI with latitude and longitude for the entered city
            fetchAQI(latitude, longitude);
            // Call fetch5DayForecast with latitude and longitude
            fetch5DayForecast(latitude, longitude);
        })
        .catch(error => console.error('Error:', error));
} 

function displayWeather(data, location) {
    // Accessing correct properties from the data object
    var temperature = convertKelvinToCelsius(data.main.temp);
    var windSpeed = data.wind.speed;
    var clouds = data.clouds.all;
    var visibility = data.visibility;
    var weatherDescription = data.weather[0].description;
    // Add a data attribute to store the temperature in Celsius
    var temperatureCelsius = temperature;

    var weatherCard = document.getElementById("weatherCard");
    weatherCard.innerHTML = `
        <h2>${location}</h2>
        <p>Temperature: ${temperature}°C</p>
        <p>Wind Speed: ${windSpeed} m/s</p>
        <p>Clouds: ${clouds}%</p>
        <p>Visibility: ${visibility} meters</p>
        <p>Weather: ${weatherDescription}</p>
    `;
   
}

function convertKelvinToCelsius(tempKelvin) {
    return (tempKelvin - 273.15).toFixed(2); // Convert Kelvin to Celsius and round to 2 decimal places
}

function updatePlaceholder(location) {
    document.getElementById("locationInput").placeholder = location;
}
function fetchAQI(latitude, longitude) {
    fetch(`https://api.waqi.info/feed/geo:${latitude};${longitude}/?token=3e044acabc6746077db703410f549ddcf085e5a8`)
        .then(response => response.json())
        .then(data => {
            console.log(data); // Log the response to inspect it
            displayAQI(data);
        })
        .catch(error => console.error('Error:', error));
}

function displayAQI(data) {
    if (data && data.data && data.data.city && data.data.aqi && data.data.time) {
        var cityName = data.data.city.name || "Unknown";
        var aqiValue = data.data.aqi || "Unknown";
        var time = data.data.time.s || "Unknown";
        var aqiWidget = document.getElementById("aqiWidget");
        aqiWidget.innerHTML = `
            <p>City: ${cityName}</p>
            <p>AQI: ${aqiValue}</p>
            <p>Time: ${time}</p>
        `;
    } else {
        var aqiWidget = document.getElementById("aqiWidget");
        aqiWidget.innerHTML = "<p>No AQI data available</p>";
        }
    }
    function fetch5DayForecast(latitude, longitude) {
        fetch(`https://api.openweathermap.org/data/2.5/forecast?lat=${latitude}&lon=${longitude}&appid=c30126dea994df88110129cd4db5189d`)
            .then(response => response.json())
            .then(data => {
                display5DayForecast(data);
            })
            .catch(error => console.error('Error:', error));
}
// Function to generate a random color in hexadecimal format
function getRandomColor() {
    return '#' + Math.floor(Math.random() * 16777215).toString(16);
}
function display5DayForecast(data) {
    const forecastSlider = document.querySelector('.forecast-slider');
    forecastSlider.innerHTML = ''; // Clear previous content

    const canvas = document.createElement('canvas');
    canvas.id = 'temperatureChart';
    forecastSlider.appendChild(canvas);

    const ctx = canvas.getContext('2d');
    const days = new Set(); // Using a Set to store unique days
    const temperatureData = {}; // Object to store temperature data for each day

    // Process the API response to extract temperature data for each day
    data.list.forEach(dayData => {
        const date = new Date(dayData.dt * 1000);
        const day = date.toLocaleDateString('en-US', { weekday: 'short' });

        // Add the day to the Set if it doesn't already exist
        days.add(day);

        // Initialize an array to store temperature data for the day if it doesn't already exist
        if (!temperatureData[day]) {
            temperatureData[day] = [];
        }

        // Extract temperature data for the current time period and add it to the array
        const temperature = convertKelvinToCelsius(dayData.main.temp);
        temperatureData[day].push(parseFloat(temperature));
    });

    // Create arrays for labels (days) and datasets (temperature variations)
    const labels = Array.from(days);
    const datasets = labels.map(day => {
        return {
            label: day,
            data: temperatureData[day] || [], // Ensure data array exists, if not, use an empty array
            backgroundColor: getRandomColor(), // You can define a function to generate random colors
        };
    });

    new Chart(ctx, {
        type: 'bar', // Use a bar chart instead of a line chart
        data: {
            labels: labels,
            datasets: datasets,
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true,
                    title: {
                        display: true,
                        text: 'Temperature (°C)',
                        color: 'white'
                    },
                    ticks: {
                        color: 'white' // Set color of Y-axis ticks
                    }
                },
                x: {
                    title: {
                        display: true,
                        text: 'Day',
                        color: 'white'
                    },
                    ticks: {
                        color: 'white' // Set color of X-axis ticks
                    }
                }
            }
        }
    });
}

