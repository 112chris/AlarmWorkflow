(function ($) {

	  $.fn.simpleClock = function () {

		// Define weekdays and months
		var weekdays = ["Sonntag", "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag"]
		var months = ["01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"];

		// getTime - Where the magic happens ...
		function getTime() {
		  var date = new Date(),
		  hour = date.getHours();
		  return {
			day: weekdays[date.getDay()],
			date: appendZero(date.getDate()),
			month: months[date.getMonth()],
			hour: appendZero(hour),
			year: date.getYear() + 1900,
			minute: appendZero(date.getMinutes()),
			second: appendZero(date.getSeconds())
		  };
		}

		// appendZero - If the number is less than 10, add a leading zero. 
		function appendZero(num) {
		  if (num < 10) {
			return "0" + num;
		  }
		  return num;
		}

		// refreshTime - Build the clock.
		function refreshTime() {
		  var now = getTime();
		  $('#date').html(now.day + ', ' + now.date + '.' + now.month + '.' + now.year);
		  $('#time').html("<span class='hour'>" + now.hour + "</span>:" + "<span class='minute'>" + now.minute + "</span>:" + "<span class='second'>" + now.second + "</span>");
		}

		// Tick tock - Run the clock.
		refreshTime();
		setInterval(refreshTime, 1000);

	  };
	})(jQuery);