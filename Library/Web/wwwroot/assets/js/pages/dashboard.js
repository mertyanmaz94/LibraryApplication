var KTDashboard = function () {

    function GetMonthName(monthNumber) {
        var months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
        return months[monthNumber];
    }

    function GetDays()
    {
        var data = [];
        for (var i = 14; i >= 0; i--)
        {
            var date = new Date();
            date.setDate(date.getDate() - i);
            var dateStr = date.toString();
            var monthName = GetMonthName(date.getMonth());
            var split = dateStr.split(" ");
            data.push(monthName + " " + split[2]);
        }
        return data;
    }

    function GetNumberOfCampaignCodesByDay(campaignCodes)
    {
        var campaignCodesCount = [];
        var days = GetDays();
        if (campaignCodes.length > 0)
        {
            for (var i = 0; i < days.length; i++) {
                var campaignCodesRequest = campaignCodes.filter(function (item)
                {
                    var pieces = item.lastGivenDate.split('-');
                    var dayPiece = pieces[2].split('T');
                    var dayPieces = days[i].split(" ");
                    return dayPiece[0] == dayPieces[1];
                });
                campaignCodesCount.push(campaignCodesRequest.length);
            }
        }
        else
        {
            for (var i = 0; i < days.length; i++)
            {
                campaignCodesCount.push(0);
            }
        }
        return campaignCodesCount;
    }

    function GetNumberOfUsersByDay(users)
    {
        var usersCount = [];
        var days = GetDays();
        if (users.length > 0)
        {
            for (var i = 0; i < days.length; i++)
            {
                var registeredUsers = users.filter(function (item)
                {
                    var pieces = item.registrationDate.split('-');
                    var dayPiece = pieces[2].split('T');
                    var dayPieces = days[i].split(" ");
                    return dayPiece[0] == dayPieces[1];
                });
                usersCount.push(registeredUsers.length);
            }
        }
        else
        {
            for (var i = 0; i < days.length; i++)
            {
                usersCount.push(0);
            }
        }
        return usersCount;
    }

    function GetNumberOfUnicUserLoginLogsByDay(userLoginLogs) {
        var userLoginLogsCount = [];
        var days = GetDays();
        if (userLoginLogs.length > 0) {
            for (var i = 0; i < days.length; i++) {
                var loginlogs = GetFilteredLoginLogs(userLoginLogs, days[i]);
                userLoginLogsCount.push(GetUnicLoginLogCount(loginlogs));
            }
        }
        else {
            for (var i = 0; i < days.length; i++) {
                userLoginLogsCount.push(0);
            }
        }
        return userLoginLogsCount;
    }

    function GetNumberOfAllUserLoginLogsByDay(userLoginLogs) {
        var userLoginLogsCount = [];
        var days = GetDays();
        if (userLoginLogs.length > 0) {
            for (var i = 0; i < days.length; i++) {
                var loginlogs = GetFilteredLoginLogs(userLoginLogs, days[i]);
                userLoginLogsCount.push(loginlogs.length);
            }
        } else {
            for (var i = 0; i < days.length; i++) {
                userLoginLogsCount.push(0);
            }
        }
        return userLoginLogsCount;
    }

    function GetNumberOfCampaignsByDate(activeCampaignsCount, endedCampaignsCount, futureCampaignsCount) {
        var campaignsCount = [];
        campaignsCount = AddValueToArray(campaignsCount, activeCampaignsCount);
        campaignsCount = AddValueToArray(campaignsCount, endedCampaignsCount);
        campaignsCount = AddValueToArray(campaignsCount, futureCampaignsCount);

        return campaignsCount;
    }

    function AddValueToArray(array, value) {
        if (value != null) {
            array.push(value);
        } else {
            array.push(0);
        }
        return array;
    }

    function GetFilteredLoginLogs(userLoginLogs, day) {
        var loginlogs = userLoginLogs.filter(function (item) {
            var pieces = item.insertionDate.split('-');
            var dayPiece = pieces[2].split('T');
            var dayPieces = day.split(" ");
            return (dayPiece[0] == dayPieces[1]);
        });
        return loginlogs;
    }

    function GetUnicLoginLogCount(loginlogs) {
        var UserIdList = loginlogs.map(function (log) {
            return log.userID;
        });
        var unicLoginlogs = UserIdList.filter(function (item, j, sites) {
            return j == sites.indexOf(item);
        });
        return unicLoginlogs.length;
    }

    var bandwidthChart = function (users) {
        if ($('#kt_chart_bandwidth1').length == 0) {
            return;
        }
        var ctx = document.getElementById("kt_chart_bandwidth1").getContext("2d");
        var gradient = ctx.createLinearGradient(0, 0, 0, 240);
        gradient.addColorStop(0, Chart.helpers.color('#d1f1ec').alpha(1).rgbString());
        gradient.addColorStop(1, Chart.helpers.color('#d1f1ec').alpha(0.3).rgbString());
        var config = {
            type: 'line',
            data: {
                labels: GetDays(),
                datasets: [
                    {
                        label: "Registered members",
                        backgroundColor: gradient,
                        borderColor: KTApp.getStateColor('success'),
                        pointBackgroundColor: Chart.helpers.color('#000000').alpha(0).rgbString(),
                        pointBorderColor: Chart.helpers.color('#000000').alpha(0).rgbString(),
                        pointHoverBackgroundColor: KTApp.getStateColor('danger'),
                        pointHoverBorderColor: Chart.helpers.color('#000000').alpha(0.1).rgbString(),
                        //fill: 'start',
                        data: GetNumberOfUsersByDay(users)
                    }
                ]
            },
            options: {
                title: {
                    display: false,
                },
                tooltips: {
                    mode: 'nearest',
                    intersect: false,
                    position: 'nearest',
                    xPadding: 10,
                    yPadding: 10,
                    caretPadding: 10
                },
                legend: {
                    display: false
                },
                responsive: true,
                maintainAspectRatio: false,
                scales: {
                    xAxes: [
                        {
                            display: false,
                            gridLines: false,
                            scaleLabel: {
                                display: true,
                                labelString: 'Month'
                            }
                        }
                    ],
                    yAxes: [
                        {
                            display: false,
                            gridLines: false,
                            scaleLabel: {
                                display: true,
                                labelString: 'Value'
                            },
                            ticks: {
                                beginAtZero: true
                            }
                        }
                    ]
                },
                elements: {
                    line: {
                        tension: 0.0000001
                    },
                    point: {
                        radius: 4,
                        borderWidth: 12
                    }
                },
                layout: {
                    padding: {
                        left: 0,
                        right: 0,
                        top: 10,
                        bottom: 0
                    }
                }
            }
        };
        var chart = new Chart(ctx, config);
    }

    var bandwidthChartCampaignCodes = function (campaignCodes) {
        if ($('#kt_chart_bandwidth2').length == 0) {
            return;
        }
        var ctx = document.getElementById("kt_chart_bandwidth2").getContext("2d");
        var gradient = ctx.createLinearGradient(0, 0, 0, 240);
        gradient.addColorStop(0, Chart.helpers.color('#d1f1ec').alpha(1).rgbString());
        gradient.addColorStop(1, Chart.helpers.color('#d1f1ec').alpha(0.3).rgbString());
        var config = {
            type: 'line',
            data: {
                labels: GetDays(),
                datasets: [
                    {
                        label: "Campaign Code Request",
                        backgroundColor: gradient,
                        borderColor: KTApp.getStateColor('success'),
                        pointBackgroundColor: Chart.helpers.color('#000000').alpha(0).rgbString(),
                        pointBorderColor: Chart.helpers.color('#000000').alpha(0).rgbString(),
                        pointHoverBackgroundColor: KTApp.getStateColor('danger'),
                        pointHoverBorderColor: Chart.helpers.color('#000000').alpha(0.1).rgbString(),
                        //fill: 'start',
                        data: GetNumberOfCampaignCodesByDay(campaignCodes)
                    }
                ]
            },
            options: {
                title: {
                    display: false,
                },
                tooltips: {
                    mode: 'nearest',
                    intersect: false,
                    position: 'nearest',
                    xPadding: 10,
                    yPadding: 10,
                    caretPadding: 10
                },
                legend: {
                    display: false
                },
                responsive: true,
                maintainAspectRatio: false,
                scales: {
                    xAxes: [
                        {
                            display: false,
                            gridLines: false,
                            scaleLabel: {
                                display: true,
                                labelString: 'Month'
                            }
                        }
                    ],
                    yAxes: [
                        {
                            display: false,
                            gridLines: false,
                            scaleLabel: {
                                display: true,
                                labelString: 'Value'
                            },
                            ticks: {
                                beginAtZero: true
                            }
                        }
                    ]
                },
                elements: {
                    line: {
                        tension: 0.0000001
                    },
                    point: {
                        radius: 4,
                        borderWidth: 12
                    }
                },
                layout: {
                    padding: {
                        left: 0,
                        right: 0,
                        top: 10,
                        bottom: 0
                    }
                }
            }
        };
        var chart = new Chart(ctx, config);
    }

    var profitShare = function (activeCampaignsCount, endedCampaignsCount, futureCampaignsCount) {
        if (!KTUtil.getByID('kt_chart_profit_share')) {
            return;
        }
        var randomScalingFactor = function () {
            return Math.round(Math.random() * 100);
        };
        var config = {
            type: 'doughnut',
            data: {
                datasets: [
                    {
                        data: GetNumberOfCampaignsByDate(activeCampaignsCount, endedCampaignsCount, futureCampaignsCount),
                        backgroundColor: [
                            KTApp.getStateColor('success'),
                            KTApp.getStateColor('danger'),
                            KTApp.getStateColor('brand')
                        ]
                    }
                ],
                labels: [
                    'Active ',
                    'Ended',
                    'Future'
                ]
            },
            options: {
                cutoutPercentage: 75,
                responsive: true,
                maintainAspectRatio: false,
                legend: {
                    display: false,
                    position: 'top'
                },
                title: {
                    display: false,
                    text: 'Technology'
                },
                animation: {
                    animateScale: true,
                    animateRotate: true
                },
                tooltips: {
                    enabled: true,
                    intersect: false,
                    mode: 'nearest',
                    bodySpacing: 5,
                    yPadding: 10,
                    xPadding: 10,
                    caretPadding: 0,
                    displayColors: false,
                    backgroundColor: KTApp.getStateColor('brand'),
                    titleFontColor: '#ffffff',
                    cornerRadius: 4,
                    footerSpacing: 0,
                    titleSpacing: 0
                }
            }
        };
        var ctx = KTUtil.getByID('kt_chart_profit_share').getContext('2d');
        var myDoughnut = new Chart(ctx, config);
    }

    var dailySales = function (userLoginLogs) {
        var chartContainer = KTUtil.getByID('kt_chart_daily_sales');
        if (!chartContainer) {
            return;
        }
        var chartData = {
            labels: GetDays(),
            datasets: [
                {
                    label: 'unic',
                    backgroundColor: KTApp.getStateColor('success'),
                    data: GetNumberOfUnicUserLoginLogsByDay(userLoginLogs)
                },
                {
                    label: 'total',
                    backgroundColor: '#f3f3fb',
                    data: GetNumberOfAllUserLoginLogsByDay(userLoginLogs)
                }
            ]
        };
        var chart = new Chart(chartContainer,
            {
                type: 'bar',
                data: chartData,
                options: {
                    title: {
                        display: false,
                    },
                    tooltips: {
                        intersect: false,
                        mode: 'nearest',
                        xPadding: 10,
                        yPadding: 10,
                        caretPadding: 10
                    },
                    legend: {
                        display: false

                    },
                    responsive: true,
                    maintainAspectRatio: false,
                    barRadius: 4,
                    scales: {
                        xAxes: [
                            {
                                display: false,
                                gridLines: false,
                                stacked: true
                            }
                        ],
                        yAxes: [
                            {
                                display: false,
                                stacked: true,
                                gridLines: false
                            }
                        ]
                    },
                    layout: {
                        padding: {
                            left: 0,
                            right: 0,
                            top: 0,
                            bottom: 0
                        }
                    }
                }
            });
    }

    return {
        init: function (users, userLoginLogs, activeCampaignsCount, endedCampaignsCount, futureCampaignsCount, campaignCodes) {
            bandwidthChart(users);
            dailySales(userLoginLogs);
            profitShare(activeCampaignsCount, endedCampaignsCount, futureCampaignsCount);
            bandwidthChartCampaignCodes(campaignCodes);
        }
    };
}();
