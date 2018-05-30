<template>
  <div class="content">
    <div class="container-fluid">
      <div class="row">

        <div class="col-md-12">
          <card>
            <h4 slot="header" class="card-title">Créer un rendez-vous</h4>
            <form>
              <div class="row">
                <div class="col-md-4">
                  <fg-input type="date"
                            label="Date*"
                            placeholder="25/05/2018"
                            v-model="rendezVous.Date">
                  </fg-input>
                </div>
                <div class="col-md-4">
                  <fg-input type="text"
                            label="Commentaire"
                            placeholder="Commentaire"
                            v-model="rendezVous.Comment">
                  </fg-input>
                </div>
                <div class="col-md-4">
                  <fg-input type="number"
                            label="Patient*"
                            placeholder="5"
                            v-model="rendezVous.Patient_Id">
                  </fg-input>
                </div>
              </div>
              <div class="text-center">
                <button type="submit" class="btn btn-info btn-fill float-right" @click.prevent="createRendezvous">
                  <i class="fa fa-save" aria-hidden="true"></i> Enregistrer
                </button>
              </div>
              <div class="clearfix"></div>
            </form>
          </card>
        </div>

        <div class="col-12">
          <card class="card-plain">
            <template slot="header">
              <h4 class="card-title">Rendez-vous</h4>
              <p class="card-category">La liste des rendez-vous</p>
            </template>
            <div class="table-responsive">
              <l-table class="table-hover"
                      @delete="deleteMethod"
                      :columns="rendezVousList.columns"
                      :data="rendezVousList.data"
                      :labels="rendezVousList.labels"
                      :routeName="'EditRendezVous'">
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

  const tableColumns = ['Id', 'Date', 'Comment', 'Patient'];
  const tableColumns2 = ['ID', 'Date', 'Comment', 'Patient'];
  var errors = [];
  var warnings = [];

  export default {
    components: {
      LTable,
      Card
    },
    data () {
      return {
        rendezVousList: {
          columns: [...tableColumns],
          labels: [...tableColumns2],
          data: [],
        },
        rendezVous: {
          Date: null,
          Comment: null,
          Patient_Id: null,
        }
      }
    },
    created() {
      this.$http.get(`http://localhost:2573/api/rendezvous`)
      .then(response => {
        this.rendezVousList.data = response.data
      })
      .catch(e => {
        errors.push(e)
      });
    },
    methods: {
      checkForm:function() {
        warnings = [];
        if(!this.rendezVous.Date) warnings.push("Le champs `Date` est initialisé à 0");
        if(!this.rendezVous.Patient_Id) warnings.push("Le champs `Patient` est requis");
        if(warnings.length)
        {
          var template = `<span>Ouups une erreur s'est produite ! <b>Doctor's</b> <p v-if="warnings.length">
                    <b>Veuillez corriger ces avertissement(s):</b>
                    <ul>
                      <li v-for="warning in warnings" v-if="warning">{{ warning }}</li>
                    </ul>
                  </p></span>`;
          this.notifyVue('top', 'center', 'warning', template);
        }

      },
      createRendezvous () {
        this.checkForm();
        this.$http.post(`http://localhost:2573/api/rendezvous/create`,this.rendezVous)
        .then(response => {
            this.$http.get(`http://localhost:2573/api/rendezvous/`)
            .then(response => {
              this.rendezVousList.data = response.data
            })
            var template = `<span>Operation Réussie ! <b>Doctor's</b> </span>`;
            this.notifyVue('top', 'center', 'success', template);
        })
        .catch(e => {
          errors = [];
          errors.push(e)
          console.log(e);
          var template = `<span>Ouups une erreur s'est produite ! <b>Doctor's</b> <p v-if="errors.length">
                    <b>Please correct the following error(s):</b>
                    <ul>
                      <li v-for="error in errors" v-if="error.message">{{ error.message }} -> <span v-if="error.response.data.ExceptionMessage">{{ error.response.data.ExceptionMessage }}</span></li>
                    </ul>
                  </p></span>`;
          this.notifyVue('top', 'center', 'danger', template)
        })
      },
      deleteMethod (id) {
        this.$http.get(`http://localhost:2573/api/rendezvous/delete/`+id)
        .then(response => {
            this.$http.get(`http://localhost:2573/api/rendezvous`)
            .then(response => {
              this.rendezVousList.data = response.data
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
            return {errors: errors, warnings: warnings}
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
