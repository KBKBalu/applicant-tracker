(function (angular) {

    angular.module('sbAdminApp').constant('fieldsLengthRestrictions', {

        validator: {

            pattern: {

                name: 50,

                Email: /^[a-z]+[a-z0-9._]+@[a-z]+\.[a-z.]{2,5}$/,

                description: 250,

                Mobile: /^[7-9][0-9]{9}$/
            },


            errormessage: {

                name: 'Required feild',

                Email: 'Enter Valid EmailId',

                Mobile: 'Enter Valid Mobile'

            }

        },


    });

})

(angular);