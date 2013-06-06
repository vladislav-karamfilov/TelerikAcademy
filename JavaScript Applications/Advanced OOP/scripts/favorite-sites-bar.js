var Url = Class.create({
    init: function (title, link) {
        this.title = title;
        this.link = link;
    }
});

var Folder = Class.create({
    init: function (title, urls) {
        this.title = title;
        this.urls = urls;
    }
});

var FavoriteSitesBar = Class.create({
    init: function (urls, folders) {
        this.urls = urls;
        this.folders = folders;
    },
    render: function (containerId) {
        var container,
            i,
            urlsCount,
            foldersCount;

        container = document.getElementById(containerId);

        urlsCount = this.urls.length;
        for (i = 0; i < urlsCount; i++) {
            this._renderUrl(this.urls[i], container);
        }

        foldersCount = this.folders.length;
        for (i = 0; i < foldersCount; i++) {
            this._renderFolder(this.folders[i], container);
        }
    },
    _renderUrl: function (url, container) {
        var urlContainer = document.createElement("a");
        urlContainer.setAttribute("class", "fav-url");
        urlContainer.innerHTML = url.title;
        urlContainer.setAttribute("href", url.link);
        urlContainer.addEventListener("click", function (ev) {
            if (!ev) {
                ev = window.event;
            }

            if (ev.preventDefault) {
                ev.preventDefault();
            }

            if (ev.stopPropagation) {
                ev.stopPropagation();
            }

            var tab = window.open(url.link, '_blank');
            tab.focus();
        }, false);

        container.appendChild(urlContainer);
    },
    _renderFolder: function (folder, container) {
        var folderContainer,
            urlsContainer,
            urlListItem,
            urlsCount;

        folderContainer = document.createElement("div");
        folderContainer.setAttribute("class", "fav-folder");
        folderContainer.innerHTML = folder.title;
        
        urlsContainer = document.createElement("ul");
        urlsContainer.style.display = "none";
        urlsContainer.style.padding = "0";

        urlsCount = folder.urls.length;
        for (i = 0; i < urlsCount; i++) {
            urlListItem = document.createElement("li");
            this._renderUrl(folder.urls[i], urlListItem);
            urlsContainer.appendChild(urlListItem);
        }

        folderContainer.appendChild(urlsContainer);

        folderContainer.addEventListener("mouseover", function (ev) {
            if (!ev) {
                ev = window.event;
            }

            if (ev.preventDefault) {
                ev.preventDefault();
            }

            if (ev.stopPropagation) {
                ev.stopPropagation();
            }

            urlsContainer.style.display = "block";
        }, false);

        folderContainer.addEventListener("mouseout", function (ev) {
            if (!ev) {
                ev = window.event;
            }

            if (ev.preventDefault) {
                ev.preventDefault();
            }

            if (ev.stopPropagation) {
                ev.stopPropagation();
            }

            urlsContainer.style.display = "none";
        }, false);

        container.appendChild(folderContainer);
    }
});