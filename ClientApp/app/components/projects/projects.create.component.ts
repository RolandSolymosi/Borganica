import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router'
import { Http } from '@angular/http';
import { ProjectsService, CreateProjectDto, GeoLocationDto, State } from './projects.service';

@Component({
    selector: 'project.create',
    templateUrl: './projects.create.component.html',
    providers: [ProjectsService]
})
export class ProjectCreateComponent implements OnInit {
    private project: CreateProjectDto;

    constructor(
        private procectsService: ProjectsService,
        private router: Router
    ) { }

    saveProject(): void {
        this.procectsService.add(this.project).subscribe(data => {
            this.router.navigate(['./projects']);
        });
    }

    ngOnInit(): void {
        this.project = new CreateProjectDto("New Project", new GeoLocationDto(0, 0, ""), 0); 
    }
}