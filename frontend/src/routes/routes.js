import DashboardLayout from '../components/Dashboard/Layout/DashboardLayout.vue'
// GeneralViews
import NotFound from '../components/GeneralViews/NotFoundPage.vue'

// Admin pages
import Overview from 'src/components/Dashboard/Views/Overview.vue'
import PatientList from 'src/components/Dashboard/Views/PatientList.vue'
import FichePatient from 'src/components/Dashboard/Views/FichePatient.vue'
import RendezVous from 'src/components/Dashboard/Views/RendezVous.vue'
import Comptab from 'src/components/Dashboard/Views/Comptab.vue'

const routes = [
  {
    path: '/',
    component: DashboardLayout,
    redirect: '/doctors/overview'
  },
  {
    path: '/doctors',
    component: DashboardLayout,
    redirect: '/doctors/overview',
    children: [
      {
        path: 'overview',
        name: 'Overview',
        component: Overview
      },
      {
        path: 'fiche/:id',
        name: 'EditFiche',
        component: FichePatient
      },
      {
        path: 'fiche',
        name: 'Fiche',
        component: FichePatient
      },
      {
        path: 'patients',
        name: 'Patients',
        component: PatientList
      },
      {
        path: 'rendez-vous',
        name: 'RendezVous',
        component: RendezVous
      },
      {
        path: 'rendez-vous/:id',
        name: 'EditRendezVous',
        component: RendezVous
      },
      {
        path: 'comptabilite',
        name: 'Comptabilite',
        component: Comptab
      },
      {
        path: 'comptabilite/:id',
        name: 'EditComptabilite',
        component: Comptab
      },
    ]
  },
  { path: '*', component: NotFound }
]

/**
 * Asynchronously load view (Webpack Lazy loading compatible)
 * The specified component must be inside the Views folder
 * @param  {string} name  the filename (basename) of the view to load.
function view(name) {
   var res= require('../components/Dashboard/Views/' + name + '.vue');
   return res;
};**/

export default routes
