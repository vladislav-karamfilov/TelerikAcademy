var helper = (function () {
    var BASE_API_PATH = 'plus/v1/';

    return {
        onSignInCallback: function (authResult) {
            gapi.client.load('plus', 'v1', function () {
                if (authResult['access_token']) {
                    $('#authOps').show('slow');
                    $('#gConnect').hide();
                    helper.profile();
                    $('#profile').show('slow');
                    $('#YouTube').show(1000);
                } else if (authResult['error']) {
                    console.log('There was an error: ' + authResult['error']);
                    $('#authResult').append('Logged out');
                    $('#authOps').hide('slow');
                    $('#profile').hide('slow');
                    $('#gConnect').show();
                    $('#YouTube').hide('slow');
                }
            });
        },

        disconnect: function () {
            $.ajax({
                type: 'GET',
                url: 'https://accounts.google.com/o/oauth2/revoke?token=' +
                    gapi.auth.getToken().access_token,
                async: false,
                contentType: 'application/json',
                dataType: 'jsonp',
                success: function (result) {
                    console.log('revoke response: ' + result);
                    $('#authOps').hide();
                    $('#authResult').empty();
                    $('#profile').hide('slow');
                    $('#gConnect').show();
                    $('#YouTube').hide('slow');
                },
                error: function (e) {
                    console.log(e);
                }
            });
        },

        profile: function () {
            var request = gapi.client.plus.people.get({ 'userId': 'me' });
            request.execute(function (profile) {
                $('#profile').empty();
                if (profile.error) {
                    $('#profile').append(profile.error);
                    return;
                }
                $('#profile').append(
                    $('<p><img src=\"' + profile.image.url + '\"></p>'));
                $('#profile').append(
                    $('<p>' + profile.displayName + '</p>'));
            });
        }
    };
})();