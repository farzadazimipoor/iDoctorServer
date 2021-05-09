//=================jvectorMap================================
var visitorsData = {}; //for jvectormap
var allVisits = [];    //for sparklines
$.ajax({
    type: 'Get',
    url: "/Admin/Home/GetCountriesVisits",
    success: function (response) {
        if (response) {
            $.each(response, function (index, obj) {
                //We can access the object using obj or this   

                visitorsData[obj.CountryCode] = obj.Visitors;
                //visitorsData = { IR : 100, IQ : 70};   

                allVisits.push(obj.Visitors);
                //allVisits = [200,134,95];
            });

            //World map by jvectormap
            $('#world-map').vectorMap({
                map: 'world_mill_en',
                backgroundColor: "transparent",
                regionStyle: {
                    initial: {
                        fill: '#e4e4e4',
                        "fill-opacity": 1,
                        stroke: 'none',
                        "stroke-width": 0,
                        "stroke-opacity": 1
                    }
                },
                series: {
                    regions: [{
                        values: visitorsData,
                        scale: ["#92c1dc", "#ebf4f9"],
                        normalizeFunction: 'polynomial'
                    }]
                },
                onRegionLabelShow: function (e, el, code) {
                    if (typeof visitorsData[code] != "undefined") {
                        var country = el.html();
                        switch (code) {
                            case "IR":
                                country = 'Iran';
                                break;
                            case "IQ":
                                country = 'Iraq';
                                break;
                            case "AF":
                                country = 'Afghanistan';
                                break;
                            case "SA":
                                country = 'Saudi Arabia';
                                break;
                            case "KW":
                                country = 'Kwait';
                                break;

                        }
                        if (country != el.html()) {
                            el.html(country + ': ' + visitorsData[code] + ' visitors ');
                        } else {
                            el.html(country + ': ' + visitorsData[code] + ' visitirs');
                        }
                    }
                }
            });

            //SparkLine charts=====================================================
            $('#sparkline-2').sparkline(allVisits, {
                type: 'line',
                lineColor: '#92c1dc',
                fillColor: "#ebf4f9",
                height: '50',
                width: '250'
            });
            //End SparkLine charts ================================================
        }
    },
    error: function () {
        alert("هەڵە لە پەیوەندی بە سیرڤر");
    }
});
//End Jvector Map============================================

//Fix for charts under tabs
$('.box ul.nav a').on('shown.bs.tab', function () {
    area.redraw();
    donut.redraw();
    line.redraw();
});