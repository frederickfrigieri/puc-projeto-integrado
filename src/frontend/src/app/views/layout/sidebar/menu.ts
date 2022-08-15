import { MenuItem } from './menu.model';

export const MENU: MenuItem[] = [
  {
    label: 'Dashboard',
    icon: 'home',
    link: '/dashboard'
  },
  {
    label: 'OMS',
    isTitle: true
  },
  {
    label: 'Pedidos',
    icon: 'clipboard',
    link: 'oms/pedidos'
  },
  {
    label: 'Impressão Etiqueta',
    icon: 'printer',
    link: 'oms/impressao-etiqueta'
  },
  {
    label: 'Separação',
    icon: 'layers',
    link: 'oms/separacao'
  },
  {
    label: 'Despacho',
    icon: 'send',
    link: 'oms/despacho'
  },


  //WMS
  {
    label: 'WMS',
    isTitle: true
  },
  {
    label: 'Estoque',
    icon: 'codesandbox',
    link: '/wms/estoque'
  },
  {
    label: 'Produtos',
    icon: 'gift',
    link: '/wms/produtos'
  },
  {
    label: 'Recebimento',
    icon: 'repeat',
    link: '/wms/estoque'
  },
  {
    label: 'Nota de Entrada',
    icon: 'file-plus',
    link: '/wms/estoque'
  },

  //TMS
  {
    label: 'TMS',
    isTitle: true
  },
  {
    label: 'Encomendas',
    icon: 'package',
    link: 'tms/encomendas'
  },
  {
    label: 'Transportadoras',
    icon: 'truck',
    link: 'tms/transportadoras'
  }
];
