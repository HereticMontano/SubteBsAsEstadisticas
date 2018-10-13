function NewInstanceChart(id, horasNormal, horasSuspendido, escala) {

	var t = {
		yAxes: [{
			scaleLabel: {
				display: true,
				labelString: 'Horas'
			},
			ticks: {
				min: 0,
				max: escala,
				stepSize: 1
			}
		}]
	};

	var canvas = $("#" + id)[0].getContext('2d');
	return new Chart(canvas, {
		type: 'bar',
		data: {
			labels: ["Linea A", "Linea B", "Linea C", "Linea D", "Linea E", "Linea H"],
			datasets: [{
				data: horasNormal,
				label: "Minutos normales",
				backgroundColor: [
					'rgb(5, 173, 222)',
					'rgb(233, 22, 39)',
					'rgb(4, 106, 180)',
					'rgb(8, 127, 105)',
					'rgb(109, 34, 129)',
					'rgb(255, 202, 3)'
				],
				borderWidth: 1
			},
			{
				data: horasSuspendido,
				label: "Minutos suspendida",
				backgroundColor: [
					'rgb(5, 173, 222)',
					'rgb(233, 22, 39)',
					'rgb(4, 106, 180)',
					'rgb(8, 127, 105)',
					'rgb(109, 34, 129)',
					'rgb(255, 202, 3)'
				],				
				borderColor: [
					'rgba(0,0,0,1)',
					'rgba(0,0,0,1)',
					'rgba(0,0,0,1)',
					'rgba(0,0,0,1)',
					'rgba(0,0,0,1)',
					'rgba(0,0,0,1)',
				],
				borderWidth: 3
			}]
		},
		options: {
			legend: {
				display: false
			},
			scales: {
				yAxes : t.yAxes
			}
		}
	});
}