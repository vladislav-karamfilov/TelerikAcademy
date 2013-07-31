var UI = (function () {
    function getLoginForm() {
        var html =
            '<div id="login-form-container">\
                <form>\
                    <div id="login-form">\
                        <label for="tb-login-username">Username: </label>\
                        <input type="text" id="tb-login-username" />\
                        <label for="tb-login-password">Password: </label>\
                        <input type="password" id="tb-login-password" />\
                        <button id="btn-login" class="button">Login</button>\
                    </div>\
                    <div id="register-form" style="display: none">\
                        <label for="tb-register-username">Username: </label>\
                        <input type="text" id="tb-register-username" />\
                        <label for="tb-register-nickname">Nickname: </label>\
                        <input type="text" id="tb-register-nickname" />\
                        <label for="tb-register-password">Password: </label>\
                        <input type="password" id="tb-register-password" />\
                        <button id="btn-register" class="button">Register</button>\
                    </div>\
                    <a href="#" id="btn-sign-up" class="button">Sign up</a>\
                    <a href="#" id="btn-sign-in" class="button selected">Sign in</a>\
                 </form>\
             </div>';

        return html;
    }

    function getMainGameMenuUI() {
        var html =
           '<h2 id="nickname-heading">Hello, <span id="nickname-container"></span></h2>\
            <a href="#" id="btn-logout" class="button">Logout</a>\
            <a id="btn-view-scores" class="button" href="#">View scores</a>\
            <a id="btn-view-unread-messages" class="button" href="#">View unread messages</a>\
            <a id="btn-view-all-messages" class="button" href="#">View all messages</a>\
            <div id="new-game-create-container">\
                <label for="tb-new-game-title">Title: </label>\
                <input type="text" id="tb-new-game-title" />\
                <label for="tb-new-game-password">Password: </label>\
                <input type="password" id="tb-new-game-password" />\
                <button id="btn-create-new-game" class="button">Create game</button>\
            </div>';

        return html;
    }

    function getErrorUI(errorMsg) {
        var html =
            '<div id="unknown-error">\
                <p>' + errorMsg + '</p>\
                <button class="button btn-back">Go Back</button>\
             </div>';

        return html;
    }

    function getScoresUI(scores) {
        var html = '<h1 style="text-align: center">Scores</h1>';
        html += '<table>\
                    <thead>\
                        <th>Nickname</th>\
                        <th>Score</th>\
                    </thead>\
                 <tbody>';
        for (var i = 0, scoresCount = scores.length; i < scoresCount; i++) {
            html += "<tr><td>" + scores[i].nickname + "</td><td>" + scores[i].score + "</td></tr>";
        }

        html += '</tbody>\
                 </table>';
        html += '<button class="button btn-back">Go Back</button>';
        return html;
    }

    function getOpenGamesList(games) {
        var list = '<ul class="game-list open-games">';
        for (var i = 0; i < games.length; i++) {
            var game = games[i];
            list +=
				'<li data-game-id="' + game.id + '">' +
					'<a href="#" class="btn-open-games">' +
						$("<div />").html(game.title).text() +
					'</a>' +
					'<span> by ' +
						game.creator +
					'</span>' +
				'</li>';
        }

        list += "</ul>";
        return list;
    }

    function getActiveGamesList(gamesList) {
        var list = '<ul class="game-list active-games">';
        for (var i = 0; i < gamesList.length; i++) {
            var game = gamesList[i];
            list +=
				'<li class="game-status-' + game.status + '" data-game-id="' + game.id + '" data-creator="' + game.creator + '">' +
					'<a href="#" class="btn-active-game">' +
						$("<div />").html(game.title).text() +
					'</a>' +
					'<span> by ' +
						game.creator +
					'</span>' +
				'</li>';
        }

        list += "</ul>";
        return list;
    }

    function getUnreadMessagesList(messages) {
        var messagesListItems = '';
        for (var i = 0, messagesCount = messages.length; i < messagesCount; i++) {
            messagesListItems += "<li>" + messages[i].text + "</li>";
        }

        var html =
            '<div id="unread-messages-container">\
                <h1>Unread messages</h1>\
                <ul>' + messagesListItems + '</ul>\
            </div>';

        html += '<button class="button btn-back">Go Back</button>';
        return html;
    }

    function getAllMessagesList(messages) {
        var messagesListItems = '';
        for (var i = 0, messagesCount = messages.length; i < messagesCount; i++) {
            messagesListItems += "<li>" + messages[i].text + "</li>";
        }

        var html =
            '<div id="all-messages-container">\
                <h1>All messages</h1>\
                <ul>' + messagesListItems + '</ul>\
            </div>';

        html += '<button class="button btn-back">Go Back</button>';
        return html;
    }

    function getInGameUI(data) {
        var html = '<h1>Game \'' + data.title + '\'</h1>';
        html += "<table id='game-field'>";
        var rowContent = '';
        for (var row = 0; row < 9; row++) {
            rowContent = "<tr>";
            for (var col = 0; col < 9; col++) {
                rowContent += "<td id=" + row + "-" + col + "></td>";
            }

            html += rowContent + "</tr>";
        }

        html += "</table>";
        html += '<button class="button btn-back">Go Back</button>';
        return html;
    }

    return {
        getLoginForm: getLoginForm,
        getMainGameMenuUI: getMainGameMenuUI,
        getErrorUI: getErrorUI,
        getScoresUI: getScoresUI,
        getOpenGamesList: getOpenGamesList,
        getActiveGamesList: getActiveGamesList,
        getUnreadMessagesList: getUnreadMessagesList,
        getAllMessagesList: getAllMessagesList,
        getInGameUI: getInGameUI
    }
}());