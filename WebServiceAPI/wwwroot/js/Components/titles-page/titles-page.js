define(["knockout", "dataservice", "viewmodel"],
    function (ko, ds, vm) {
return function(params) {
    let selectedTitle = ko.observable(params);
    
    let cast = ko.observable([]);
 

    ds.getCast(selectedTitle(),function(data) {
        cast(data.cast);
    })
    let titleRating = ko.observable();
    let checkVotes = ko.observable('False');
    
    
    ds.getTitleRating(selectedTitle(), function (data) {
        if(data.numVotes > 0){
            checkVotes('True');
        }
        console.log(data);
        titleRating(data);
    })

    let crew = ko.observable([]);
    
    ds.getCrew(selectedTitle(), function (data) {
        console.log(data.crew)
        crew(data.crew);
    })

    ds.getTitle(selectedTitle(), async function (data) {
        console.log(data);
        title(data);
        if (data.awards !== null) {
            await getTitlePoster(data.awards);
        }
    })

    let title = ko.observable();

    

      let getTitlePoster = async (_url) => {
                await ds.getPoster(_url);
                getImgSize(_url);
            };

            let posterHeight = ko.observable();


            /**
             * Sourced from
             * https://stackoverflow.com/questions/106828/javascript-get-image-height
             */
            let getImgSize = function (imgSrc) {
                console.log(imgSrc)
                var newImg = new Image();
                newImg.addEventListener("load", function () {
                    posterHeight(this.naturalHeight);
                    //alert(this.naturalWidth + ' ' + this.naturalHeight);
                });
                newImg.src = imgSrc;
            };

    
    return {
        selectedTitle,
        titleRating,
        crew,
        title,
        cast,
        checkVotes,
      posterHeight
    }
    }})