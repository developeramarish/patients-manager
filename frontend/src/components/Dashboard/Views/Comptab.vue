<template>
  <div class="content">
    <div class="container-fluid">
      <div class="row">

        <div class="col-md-12">
          <card>
            <h4 slot="header" class="card-title">Saisir une dépense</h4>
            <form>
              <div class="row">
                <div class="col-md-3">
                  <fg-input type="text"
                            label="Code*"
                            placeholder="#C500"
                            v-model="depense.Code">
                  </fg-input>
                </div>
                <div class="col-md-3">
                  <fg-input type="date"
                            label="Date*"
                            placeholder="25/05/2018"
                            v-model="depense.Date">
                  </fg-input>
                </div>
                <div class="col-md-3">
                  <fg-input type="text"
                            label="Mode"
                            placeholder="Chèque"
                            v-model="depense.Mode">
                  </fg-input>
                </div>
                <div class="col-md-3">
                  <fg-input type="number"
                            label="Montant*"
                            placeholder="400"
                            v-model="depense.Montant">
                  </fg-input>
                </div>
              </div>
              <div class="text-center">
                <button type="submit" class="btn btn-info btn-fill float-right" @click.prevent="createDepense">
                  <i class="fa fa-save" aria-hidden="true"></i> Enregistrer
                </button>
              </div>
              <div class="clearfix"></div>
            </form>
          </card>
        </div>

        <div class="col-md-12">
          <card>
            <h4 slot="header" class="card-title">Saisir une recette</h4>
            <form>
              <div class="row">
                <div class="col-md-4">
                  <fg-input type="text"
                            label="Code*"
                            placeholder="#C100"
                            v-model="recette.Code">
                  </fg-input>
                </div>
                <div class="col-md-4">
                  <fg-input type="date"
                            label="Date*"
                            placeholder="25/05/2018"
                            v-model="recette.Date">
                  </fg-input>
                </div>
                <div class="col-md-4">
                  <fg-input type="text"
                            label="Mode"
                            placeholder="Chèque"
                            v-model="recette.Mode">
                  </fg-input>
                </div>
              </div>
              <div class="row">

                <div class="col-md-6">
                  <fg-input type="number"
                            label="Montant*"
                            placeholder="40"
                            v-model="recette.Montant">
                  </fg-input>
                </div>
                <div class="col-md-6">
                  <fg-input type="number"
                            label="Patient"
                            placeholder="5"
                            v-model="recette.Patient_Id">
                  </fg-input>
                </div>
              </div>


              <div class="text-center">
                <button type="submit" class="btn btn-info btn-fill float-right" @click.prevent="createRecette">
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
              <h4 class="card-title">Comptabilité</h4>
              <p class="card-category">Flux</p>
            </template>
            <div class="table-responsive">
              <l-table class="table-hover"
                      @delete="deleteMethod"
                       :columns="comptabList.columns"
                       :data="comptabList.data"
                       :labels="comptabList.labels"
                       :routeName="'EditComptabilite'">
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

  const tableColumns = ['Id', 'Code', 'Date', 'Mode', 'Montant', 'Type', 'Patient'];
  const tableColumns2 = ['ID', 'Code', 'Date', 'Mode', 'Montant', 'Type', 'Patient'];
  var errors = [];
  var warnings = [];

  export default {
    components: {
      LTable,
      Card
    },
    data () {
      return {
        comptabList: {
          columns: [...tableColumns],
          labels: [...tableColumns2],
          data: [],
          errors: []
        },
        recette: {
          Code: null,
          Date: null,
          Mode: null,
          Montant: null,
          Type: 'recette',
          Patient_Id: null,
        },
        depense: {
          Code: null,
          Date: null,
          Mode: null,
          Montant: null,
          Type: 'depense'
        }
      }
    },
    created() {
      this.$http.get(`http://localhost:2573/api/comtab`)
      .then(response => {
        this.comptabList.data = response.data
      })
      .catch(e => {
        errors.push(e)
      });
    },
    methods: {
      checkFormRecette:function() {
        warnings = [];
        if(!this.recette.Code) warnings.push("Le champs `Code` est requis");
        if(!this.recette.Date) warnings.push("Le champs `Date` est initialisé à 0");
        if(!this.recette.Montant) warnings.push("Le champs `Montant` est initialisé à 0");
        if(warnings.length)
        {
          var template = `<span>Ouups une erreur s'est produite lors de la saisie d'une recette ! <b>Doctor's</b> <p v-if="warnings.length">
                    <b>Veuillez corriger ces avertissement(s):</b>
                    <ul>
                      <li v-for="warning in warnings" v-if="warning">{{ warning }}</li>
                    </ul>
                  </p></span>`;
          this.notifyVue('top', 'center', 'warning', template);
        }
      },
      checkFormDepense:function() {
        warnings = [];
        if(!this.depense.Code) warnings.push("Le champs `Code` est requis");
        if(!this.depense.Date) warnings.push("Le champs `Date` est initialisé à 0");
        if(!this.depense.Montant) warnings.push("Le champs `Montant` est initialisé à 0");
        if(warnings.length)
        {
          var template = `<span>Ouups une erreur s'est produite lors de la saisie d'une dépense ! <b>Doctor's</b> <p v-if="warnings.length">
                    <b>Veuillez corriger ces avertissement(s):</b>
                    <ul>
                      <li v-for="warning in warnings" v-if="warning">{{ warning }}</li>
                    </ul>
                  </p></span>`;
          this.notifyVue('top', 'center', 'warning', template);
        }
      },
      createRecette () {
        this.checkFormRecette();
        this.$http.post(`http://localhost:2573/api/comtab/create`,this.recette)
        .then(response => {
            this.$http.get(`http://localhost:2573/api/comtab`)
            .then(response => {
              this.comptabList.data = response.data
            })
            var template = `<span>Operation Réussie ! <b>Doctor's</b> </span>`;
            this.notifyVue('top', 'center', 'success', template);
        })
        .catch(e => {
          errors = [];
          errors.push(e)
          console.log(e);
          var template = `<span>Ouups une erreur s'est produite lors de la saisie d'une recette ! <b>Doctor's</b> <p v-if="errors.length">
                    <b>Please correct the following error(s):</b>
                    <ul>
                      <li v-for="error in errors" v-if="error.message">{{ error.message }} -> <span v-if="error.response.data.ExceptionMessage">{{ error.response.data.ExceptionMessage }}</span></li>
                    </ul>
                  </p></span>`;
          this.notifyVue('top', 'center', 'danger', template)
        })
      },
      createDepense () {
        this.checkFormDepense();
        this.$http.post(`http://localhost:2573/api/comtab/create`,this.depense)
        .then(response => {
            this.$http.get(`http://localhost:2573/api/comtab`)
            .then(response => {
              this.comptabList.data = response.data
            })
            var template = `<span>Operation Réussie ! <b>Doctor's</b> </span>`;
            this.notifyVue('top', 'center', 'success', template);
        })
        .catch(e => {
          errors = [];
          errors.push(e)
          console.log(e);
          var template = `<span>Ouups une erreur s'est produite lors de la saisie d'une dépense ! <b>Doctor's</b> <p v-if="errors.length">
                    <b>Please correct the following error(s):</b>
                    <ul>
                      <li v-for="error in errors" v-if="error.message">{{ error.message }} -> <span v-if="error.response.data.ExceptionMessage">{{ error.response.data.ExceptionMessage }}</span></li>
                    </ul>
                  </p></span>`;
          this.notifyVue('top', 'center', 'danger', template)
        })
      },
      deleteMethod (id) {
        this.$http.get(`http://localhost:2573/api/comtab/delete/`+id)
        .then(response => {
            this.$http.get(`http://localhost:2573/api/comtab`)
            .then(response => {
              this.comptabList.data = response.data
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
