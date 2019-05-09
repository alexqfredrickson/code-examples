class Article {
  constructor(id, title, url, points, time_created, list_id) {
	this.id = id;
	this.title = title;
    this.url = url;
    this.hostname = extractHostname(this.url);
    this.points = points;
    this.time_created = time_created;
    this.list_id = list_id;
  }
}


// https://stackoverflow.com/questions/8498592/extract-hostname-name-from-string
function extractHostname(url) {
    var hostname;
    //find & remove protocol (http, ftp, etc.) and get hostname

    if (url.indexOf("//") > -1) {
        hostname = url.split('/')[2];
    }
    else {
        hostname = url.split('/')[0];
    }

    //find & remove port number
    hostname = hostname.split(':')[0];
    //find & remove "?"
    hostname = hostname.split('?')[0];

    return hostname;
}


$(function() {
	console.log("Started site-main.js execution...");
	$('#welcome-modal').modal();

	const getArticlesAsync = async () => {
	  const response = await fetch(window.location.origin + "/api/articles/get");
	  const json = await response.json(); 
	  return json;
	}

	var articles = [];

	getArticlesAsync().then(result => {

		var list_id = 1;

		for (var i = 0; i < result.length; i++) {
			articles.push(
				new Article(
					result[i].Id, 
					result[i].Title, 
					result[i].Url, 
					result[i].Points, 
					result[i].TimeCreated,
					list_id
				)
			);

			list_id += 1;
		}

		// for (var i = 0; i < articles.length; i++) {
		// 	console.log(articles[i]);
		// }

		var example1 = new Vue({
			el: '.articles',
			data: {
		    	articles: articles
			}
		})

	}).catch(error => {
		console.warning(result);
	});

});