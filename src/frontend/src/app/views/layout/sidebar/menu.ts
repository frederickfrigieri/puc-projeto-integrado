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
    label: 'Parceiros',
    icon: 'clipboard',
    link: 'oms/parceiros'
  },

  //WMS
  {
    label: 'WMS',
    isTitle: true
  },
  {
    label: 'Estoques',
    icon: 'codesandbox',
    link: 'wms/estoques'
  },
  {
    label: 'Produtos',
    icon: 'gift',
    link: 'wms/produtos'
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
