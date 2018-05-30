<template>
  <div class="wrapper">
    <side-bar>
      <mobile-menu slot="content"></mobile-menu>
      <sidebar-link :to="{name:'Overview'}">
        <i class="nc-icon nc-chart-pie-36"></i>
        <p>Tableau de bord</p>
      </sidebar-link>
      <sidebar-link :to="{name:'Fiche'}">
        <i class="nc-icon nc-notes"></i>
        <p>Fiche Patient</p>
      </sidebar-link>
      <sidebar-link :to="{name:'RendezVous'}">
        <i class="nc-icon nc-watch-time"></i>
        <p>Rendez-Vous</p>
      </sidebar-link>
      <sidebar-link :to="{name:'Patients'}">
        <i class="nc-icon nc-single-02"></i>
        <p>Patients</p>
      </sidebar-link>
      <sidebar-link :to="{name:'Comptabilite'}">
        <i class="nc-icon nc-money-coins"></i>
        <p>Comptabilité</p>
      </sidebar-link>
    </side-bar>
    <div class="main-panel">
      <top-navbar></top-navbar>

      <dashboard-content @click="toggleSidebar">

      </dashboard-content>

      <content-footer></content-footer>
    </div>
  </div>
</template>
<style lang="scss">

</style>
<script>
  import TopNavbar from './TopNavbar.vue'
  import ContentFooter from './ContentFooter.vue'
  import DashboardContent from './Content.vue'
  import MobileMenu from './MobileMenu.vue'
  export default {
    components: {
      TopNavbar,
      ContentFooter,
      DashboardContent,
      MobileMenu
    },
    methods: {
      toggleSidebar () {
        if (this.$sidebar.showSidebar) {
          this.$sidebar.displaySidebar(false)
        }
      }
    }
  }

</script>
