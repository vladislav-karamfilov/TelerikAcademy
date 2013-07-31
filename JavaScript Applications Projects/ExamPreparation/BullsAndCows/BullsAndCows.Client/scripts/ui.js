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
                    <a href="#" id="btn-sign-in" class="button selected">Sign in</a>\
                    <a href="#" id="btn-sign-up" class="button">Sign up</a>\
                 </form>\
             </div>';

        return html;
    }

    function getNonSuccessfullLoginMessage() {
        var html =
            '<div id="invalid-login-container">\
                <p>Invalid username and/or password!</p>\
                <button class="button btn-back">Go Back</button>\
             </div>';

        return html;
    }

    function getNonSuccessfullRegisterMessage() {
        var html =
            '<div id="invalid-register-container">\
                <p>A user with the provided username already exists!</p>\
                <button class="button btn-back">Go Back</button>\
             </div>';

        return html;
    }

    function getMainGameMenuUI() {
        var html =
            '<div id="in-game">\
                <h3>Hello, <span id="nickname-container"></span></h3>\
                <a href="#" id="btn-logout" class="button">Logout</a>\
                <ul>\
                    <li><a id="btn-view-scores" href="#">View scores</a></li>\
                    <li><a id="btn-view-messages" href="#">View messages</a></li>\
                    <li><a id="btn-view-active-games" href="#">View your current active games</a></li>\
                    <li><a id="btn-view-open-games" href="#">View open games</a></li>\
                    <li><a id="btn-create-game-choice" href="#">Create new game</a></li>\
                </ul>\
             </div>';

        return html;
    }

    function getCreateNewGameUI() {
        var html =
           '<label for="tb-new-game-title">Title: </label>\
            <input type="text" id="tb-new-game-title"/>\
            <label for="tb-new-game-number">Number: </label>\
            <input type="text" id="tb-new-game-number" />\
            <label for="tb-new-game-password">Password: </label>\
            <input type="password" id="tb-new-game-password" />\
            <button id="btn-create-game" class="button">Create game</button>\
            <button class="button btn-back">Go Back</button>';

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
        var html = '<h1>Scores</h1>';
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

    function getActiveGamesUI(activeGames) {
        var html = "<h1>Your active games</h1>";
        html += "<ul>";
        for (var i = 0, activeGamesCount = activeGames.length; i < activeGamesCount; i++) {
            html += '<li>\
                        <a href="#" data-gameID=' +
                        activeGames[i].id + '>' + activeGames[i].title + '</a>\
                        <span> created by' + activeGames[i].creatorNickname + '</span>\
                     </li>';
        }

        html += "</ul>";
        html += '<button class="button btn-back">Go Back</button>';
        return html;
    }

    function getOpenGamesUI(openGames) {
        var html = "<h1>Open games</h1>";
        html += "<ul>";
        for (var i = 0, openGamesCount = openGames.length; i < openGamesCount; i++) {
            html += '<li>\
                        <a href="#" data-gameID=' +
                        openGames[i].id + '>' + openGames[i].title + '</a>\
                        <span> created by ' + openGames[i].creatorNickname + '</span>\
                     </li>';
        }

        html += "</ul>";
        html += '<button class="button btn-back">Go Back</button>';
        return html;
    }

    return {
        getLoginForm: getLoginForm,
        getNonSuccessfullLoginMessage: getNonSuccessfullLoginMessage,
        getNonSuccessfullRegisterMessage: getNonSuccessfullRegisterMessage,
        getMainGameMenuUI: getMainGameMenuUI,
        getErrorUI: getErrorUI,
        getScoresUI: getScoresUI,
        getActiveGamesUI: getActiveGamesUI,
        getOpenGamesUI: getOpenGamesUI,
        getCreateNewGameUI: getCreateNewGameUI
    }
}());