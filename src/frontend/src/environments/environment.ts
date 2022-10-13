// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  urlAuth: 'https://localhost:7001/api',
  urlOms: 'https://localhost:7101/api',
  urlWms: 'https://localhost:7201/api'

  // urlAuth: 'https://www.ezconet.com.br/webservices/tcc-puc/autenticacao/api',
  // urlOms: 'https://www.ezconet.com.br/webservices/tcc-puc/oms/api',
  // urlWms: 'https://www.ezconet.com.br/webservices/tcc-puc/wms/api'
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
