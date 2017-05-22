import { Component, Inject, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
import { Http } from '@angular/http';
import { ProjectsService, Project, EditProjectDto, GeoLocationDto, State } from './projects.service';

@Component({
    selector: 'project.edit',
    templateUrl: './projects.edit.component.html',
    providers: [ProjectsService]
})
export class ProjectEditComponent implements OnInit {
    private project: EditProjectDto;

    id: number;
    private sub: any;

    constructor(
        private procectsService: ProjectsService,
        private router: Router,
        private route: ActivatedRoute
    ) { }

    saveProject(): void {
        this.procectsService.update(this.project).subscribe(data => {
            this.router.navigate(['./projects']);
        });
    }

    ngOnInit(): void {
        this.sub = this.route.params.subscribe(params => {
            this.id = +params['id'];
            this.procectsService.getById(this.id).subscribe(data => {
                this.project = new EditProjectDto(
                    data.id,
                    data.name,
                    new GeoLocationDto(
                        data.location.latitude,
                        data.location.longitude,
                        data.location.cityName
                    ),
                    data.profit
                );
            });
            
        });
    }
}