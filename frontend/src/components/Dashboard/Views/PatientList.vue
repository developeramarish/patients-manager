<template>
  <div class="content">
    <div class="container-fluid">
      <div class="row">

        <div class="col-12">
          <card class="card-plain">
            <template slot="header">
              <h4 class="card-title">Patients</h4>
              <p class="card-category">La liste des patients</p>
            </template>
            <div class="table-responsive">
              <l-table class="table-hover"
                        @delete="deleteMethod"
                       :columns="patients.columns"
                       :data="patients.data"
                       :labels="patients.labels"
                       :routeName="'EditFiche'">
              </l-table>
            </div>
          </card>
        </div>

      </div>
    </div>
  </div>
</template>
<script>
  import LTable from 'src/components/UIComponents/Table.vue'
  import Card from 'src/components/UIComponents/Cards/Card.vue'

  const tableColumns2 = ['ID', 'Nom', 'Prenom', 'Date', 'CIN', 'Téléphone', 'Adresse', 'CNAM', 'Naissance', 'Profession'];
  const tableColumns = ['Id','Nom', 'Prenom', 'Date_cre', 'CIN', 'Telephone', 'Adresse', 'Matricule_CNAM', 'Date_nais', 'Profession'];
  var errors = [];

  export default {
    components: {
      LTable,
      Card
    },
    data () {
      return {
        patients: {
          columns: [...tableColumns],
          labels: [...tableColumns2],
          data: []
        },
      }
    },
    created() {
      this.$http.get(`http://localhost:2573/api/patient`)
      .then(response => {
        this.patients.data = response.data
      })
      .catch(e => {
        errors.push(e)
      })
    },
    methods: {
      deleteMethod (id) {
        this.$http.get(`http://localhost:2573/api/patient/delete/`+id)
        .then(response => {
            this.$http.get(`http://localhost:2573/api/patient`)
            .then(response => {
              this.patients.data = response.data
            })
            var template = `<span>Operation Réussie ! <b>Doctor's</b> </span>`;
            this.notifyVue('top', 'center', 'success', template);
        })
        .catch(e => {
          errors = [];
          errors.push(e)
          console.log(e);
          var template = `<span>Ouups une erreur s'est produite lors de la supression ! <b>Doctor's</b> <p v-if="errors.length">
                    <b>Please correct the following error(s):</b>
                    <ul>
                      <li v-for="error in errors" v-if="error.message">{{ error.message }} -> <span v-if="error.response.data.ExceptionMessage">{{ error.response.data.ExceptionMessage }}</span></li>
                    </ul>
                  </p></span>`;
          this.notifyVue('top', 'center', 'danger', template)
        })
      },
      notifyVue (verticalAlign, horizontalAlign, color, template) {
        const notification = {
          template: template,
          data () {
            return {errors: errors}
          },
        }
        this.$notifications.notify(
        {
          component: notification,
          icon: 'nc-icon nc-app',
          horizontalAlign: horizontalAlign,
          verticalAlign: verticalAlign,
          type: color
        })
      }
    }
  }
</script>
<style>
</style>
