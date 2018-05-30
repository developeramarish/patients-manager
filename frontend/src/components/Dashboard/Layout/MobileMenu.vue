<template>
  <ul class="nav nav-mobile-menu">

    <drop-down title="Menu">
      <a class="dropdown-item" href="#">Options</a>
      <div class="divider"></div>
      <a class="dropdown-item" href="#">Compte Utilisateur</a>
    </drop-down>

    <li class="nav-item">
      <a class="nav-link" href="#pablo">
        <span class="no-icon">Deconnecter</span>
      </a>
    </li>
  </ul>
</template>
<script>
  import DropDown from 'src/components/UIComponents/Dropdown.vue'

  export default {
    components: {
      DropDown
    }
  }
</script>
<style>
</style>
