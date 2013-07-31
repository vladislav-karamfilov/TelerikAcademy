var scoresNS = (function () {
    var Score = Class.create({
        initialize: function (name, points) {
            this.name = name;
            this.points = points;
        }
    });

    var ScoreBoard = Class.create({
        initialize: function (containerID) {
            this.container = $(containerID);
            this.scores = [];
        },
        add: function (newScore) {
            this.scores.push(newScore);
        },
        _getTopScores: function () {
            var topScores, i;
            this.scores.sort(this._orderScores);

            topScores = [];
            i = 0;
            while (i < 5 && i < this.scores.length) {
                topScores.push(this.scores[i]);
                i++;
            }

            return topScores;
        },
        render: function () {
            var topScoresList, i, topScore, topScoresCount, topScores;
            topScoresList = $("<ul></ul>");
            topScores = this._getTopScores();
            topScoresCount = topScores.length;
            for (i = 0; i < topScoresCount; i++) {
                topScore = $("<li></li>");
                topScore.html("" + (i + 1) + ". " + topScores[i].name + " - " + topScores[i].points);
                topScoresList.append(topScore);
            }

            this.container.append(topScoresList);
        },
        _orderScores: function (firstScore, secondScore) {
            return secondScore.points - firstScore.points;
        }
    });

    return {
        Score: Score,
        ScoreBoard: ScoreBoard
    }
})();