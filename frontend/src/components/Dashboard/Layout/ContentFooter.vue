<template>
  <footer class="footer">
    <div class="container-fluid">
      <nav>
        <ul class="footer-menu">
          <li>
            <router-link :to="{path:'/admin'}">Tableau de bord</router-link>
          </li>
        </ul>
      </nav>
      <div class="copyright text-center">
        &copy; Coded with
        <i class="fa fa-heart heart"></i> by
        Bochra Golli and <a href="https://github.com/sayfessyd" target="_blank">Sayf Essyd</a>

      </div>
    </div>
  </footer>
</template>
<script>
  export default {}

</script>
<style>

</style>
