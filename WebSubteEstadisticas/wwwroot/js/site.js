function NewInstanceChart(id, data) {

	var canvas = $("#" + id)[0].getContext('2d');
	return new Chart(canvas, {
		type: 'bar',
		data: {
			labels: ["Linea A", "Linea B", "Linea C", "Linea D", "Linea E", "Linea H", "Linea P"],
			datasets: [{				
				data: data,
				backgroundColor: [
					'rgb(5, 173, 222)',
					'rgb(233, 22, 39)',
					'rgb(4, 106, 180)',
					'rgb(8, 127, 105)',
					'rgb(109, 34, 129)',
					'rgb(255, 202, 3)',
					'rgb(253, 186, 45)'
				],
				borderWidth: 1
			}]
		},
		options: {
			legend: {
				display: false
			},
			scales: {
				yAxes: [{
					ticks: {
						beginAtZero: true
					}
				}]
			}
		}
	});
}