var UserProfileVM = function () {

    var self = this;
    self.Login = ko.observable('');
    self.Location = ko.observable('');
    self.avatar_url = ko.observable('');
    self.Repositories = ko.observableArray([]);

    self.HasResults = ko.computed(function() {
        return self.Login() !== '' && self.Login() !== 'undefined';
    });

    self.retrieveProfile = function () {

        var userName = $('#user-input').val();

        $.get(
            "/api/GitRepositories/" + userName,
            null,
            function (data) {

                self.Login(data.Login);
                self.Location(data.Location);
                self.avatar_url(data.avatar_url);
                self.Repositories(data.Repositories);
            });
    }
}