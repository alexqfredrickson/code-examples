var express = require('express');

express.static.mime.define({'application/woff': ['woff']});
express.static.mime.define({'application/font-woff2': ['woff2']});

var app = express();

app.get("/", function(req, res) {
    res.sendFile(__dirname + '/index.html');
});

app.use(express.static(__dirname + '/Assets/bower_components/angular'));
app.use(express.static(__dirname + '/Assets/bower_components/less/dist'));
//app.use(express.static(__dirname + '/Assets/bower_components/font-awesome/css'));
//app.use(express.static(__dirname + '/Assets/bower_components/font-awesome/fonts'));
app.use(express.static(__dirname + '/Scripts/angular'));
app.use(express.static(__dirname + '/Assets/bower_components/bootstrap/dist/css'));
app.use(express.static(__dirname + '/Assets/bower_components/angular-route'));
app.use(express.static(__dirname + '/Styles'));
app.use(express.static(__dirname + '/Views'));


app.listen(8000); //the port you want to use
