import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ChartsModule } from 'ng2-charts';

import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { ProjectsIndexComponent } from './components/projects/projects.index.component';
import { ProjectCreateComponent } from './components/projects/projects.create.component';
import { ProjectEditComponent } from './components/projects/projects.edit.component';

export const sharedConfig: NgModule = {
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        NavMenuComponent,
        ProjectsIndexComponent,
        ProjectCreateComponent,
        ProjectEditComponent,
        HomeComponent
    ],
    imports: [
        FormsModule,
        ChartsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'projects', component: ProjectsIndexComponent },
            { path: 'projects/create', component: ProjectCreateComponent },
            { path: 'projects/:id', component: ProjectEditComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
};
