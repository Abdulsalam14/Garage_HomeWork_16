$(document).ready(() => {
    let rowCount = 1;
    $("#loadMore").click(() => {
        $.ajax({
            method: "GET",
            url: "Home/LoadMore",
            data: {
                rowCount: rowCount
            },
            success: (result) => {
                if (result.trim().length > 0) {
                    $("#recentWorks").append(result);
                    rowCount++;
                } else {
                    $("#loadMore").hide();
                }
            },
            error: (error) => {
                console.log(error);
            }
        });
    });
});


$(document).ready(() => {
    let skipCount = 3;
    $("#loadMorePricing").click(() => {
        $.ajax({
            method: "GET",
            url: "Pricing/LoadMore",
            data: {
                skipCount: skipCount
            },
            success: (result) => {
                if (result.trim().length > 0) {
                    $("#pricingItems").append(result);
                    skipCount++;
                } else {
                    $("#loadMorePricing").hide();
                }
            },
            error: (error) => {
                console.log(error);
            }
        });
    });
});