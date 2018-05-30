<template>
  <div class="content">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-12">
          <card>
            <h4 slot="header" class="card-title">Editer une fiche</h4>
            <form>
              <div class="row">
                <div class="col-md-4">
                  <fg-input type="text"
                            label="Nom*"
                            placeholder="Ben Foulen"
                            v-model="patient.Nom"
                            :value="patient.Nom">
                  </fg-input>
                </div>
                <div class="col-md-4">
                  <fg-input type="text"
                            label="Prenom*"
                            placeholder="Flen"
                            v-model="patient.Prenom"
                            :value="patient.Prenom">
                  </fg-input>
                </div>
                <div class="col-md-4">
                  <fg-input type="date"
                            label="Date de création*"
                            placeholder="25/05/2018"
                            v-model="patient.Date_cre"
                            :value="patient.Date_cre">
                  </fg-input>
                </div>
              </div>
              <div class="row">
                <div class="col-md-4">
                  <fg-input type="tel"
                            label="Téléphone"
                            placeholder="+21650420350"
                            v-model="patient.Telephone"
                            :value="patient.Telephone">
                  </fg-input>
                </div>
                <div class="col-md-4">
                  <fg-input type="text"
                            label="Adresse"
                            placeholder="Rue Mohammed V"
                            v-model="patient.Adresse"
                            :value="patient.Adresse">
                  </fg-input>
                </div>
                <div class="col-md-4">
                  <fg-input type="number"
                            label="Matricule CNAM"
                            placeholder="40520350"
                            v-model="patient.Matricule_CNAM"
                            :value="patient.Matricule_CNAM">
                  </fg-input>
                </div>
              </div>
              <div class="row">
                <div class="col-md-4">
                  <fg-input type="date"
                            label="Date de naissance"
                            placeholder="20/05/1980"
                            v-model="patient.Date_nais"
                            :value="patient.Date_nais">
                  </fg-input>
                </div>
                <div class="col-md-4">
                    <fg-input type="text"
                              label="Nom Fiche*"
                              placeholder="Flen"
                              v-model="patient.Nom_fiche"
                              :value="patient.Nom_fiche">
                    </fg-input>
                </div>
                <div class="col-md-4">
                    <fg-input type="text"
                              label="Profession"
                              placeholder="Docteur"
                              v-model="patient.Profession"
                              :value="patient.Profession">
                    </fg-input>
                </div>
              </div>
              <div class="row">
                <div class="col-md-4">
                  <fg-input type="text"
                            label="CIN"
                            placeholder="11350640"
                            v-model="patient.CIN"
                            :value="patient.CIN">
                  </fg-input>
                </div>
                <div class="col-md-4">
                  <fg-input type="text"
                            label="Sexe*"
                            placeholder="m"
                            v-model="patient.Sexe"
                            :value="patient.Sexe">
                  </fg-input>
                </div>
              </div>

              <div class="text-center">
                <button type="submit" class="btn btn-info btn-fill float-right" @click.prevent="updateFiche">
                  <i class="fa fa-save" aria-hidden="true"></i> Enregistrer
                </button>
              </div>
              <div class="clearfix"></div>
            </form>
          </card>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
  import Card from 'src/components/UIComponents/Cards/Card.vue'
  var errors = [];
  var warnings = [];

  export default {
    components: {
      Card
    },
    data () {
      return {
        patient: {
          Nom: null,
          Prenom: null,
          Date_cre: null,
          CIN: null,
          Sexe: null,
          Telephone: null,
          Adresse: null,
          Matricule_CNAM: null,
          Date_nais: null,
          Nom_fiche: null,
          Profession: null
        }
      }
    },
    created() {
      if (this.$route.params.id) {
        this.$http.get(`http://localhost:2573/api/patient/`+this.$route.params.id)
        .then(response => {
          this.patient = response.data
        })
        .catch(e => {

        })
      }
    },
    methods: {
      checkForm:function() {
        warnings = [];
        if(!this.patient.Nom) warnings.push("Le champs `Nom` est requis");
        if(!this.patient.Prenom) warnings.push("Le champs `Prenom` est requis");
        if(!this.patient.Date_cre) warnings.push("Le champs `Date Création` est initialisé à 0");
        if(!this.patient.Sexe) warnings.push("Le champs `Sexe` est requis");
        if(!this.patient.Nom_fiche) warnings.push("Le champs `Nom Fiche` est requis");
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
      updateFiche () {
        this.checkForm();
        var method;
        if (this.$route.params.id) method = "update"; else method="create";
        this.$http.post(`http://localhost:2573/api/patient/`+method,this.patient)
        .then(response => {
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
