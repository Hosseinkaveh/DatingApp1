import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  {path:'',component:LoginComponent},
   {
     path:'',
    runGuardsAndResolvers:'always',
     canActivate:[AuthGuard],
     children:[
    {path:'home',component:HomeComponent},
    ]
   },
 
  {path:'register',component:RegisterComponent},
  {path:'**',component:LoginComponent,pathMatch:'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
