mainApp.factory("appointmentsService", ["$", "$rootScope", function ($, $rootScope) {
    var proxy;
    var connection;
    return {
        connect: function () {
            connection = $.hubConnection("http://localhost:22691");
            proxy = connection.createHubProxy("appointmentHub");
            connection.start();

            proxy.on("appointmentReserved", function () {
                $rootScope.$broadcast("appointmentReserved");
            });

            proxy.on("appointmentRecovered", function () {
                $rootScope.$broadcast("appointmentRecovered");
            });

            proxy.on("appointmentRecoveredForce", function () {
                $rootScope.$broadcast("appointmentRecoveredForce");
            });


            /// :: For Selected Doctor................................
            proxy.on("appointmentReservedForSelectedDoctor", function () {
                $rootScope.$broadcast("appointmentReservedForSelectedDoctor");
            });
            proxy.on("appointmentRecoveredForSelectedDoctor", function () {
                $rootScope.$broadcast("appointmentRecoveredForSelectedDoctor");
            });
            proxy.on("appointmentRecoveredForceForSelectedDoctor", function () {
                $rootScope.$broadcast("appointmentRecoveredForceForSelectedDoctor");
            });


        },
        isConnecting: function () {
            return connection.state === 0;
        },
        isConnected: function () {
            return connection.state === 1;
        },
        connectionState: function () {
            return connection.state;
        },

        reserveAppointment: function () {
            proxy.invoke("reserveAppointment")
        },

        /// :: For Selected Doctor................................
        reserveAppointmentForSelectedDoctor: function () {
            proxy.invoke("reserveAppointmentForSelectedDoctor")
        },
    }
}]);