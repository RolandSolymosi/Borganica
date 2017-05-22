import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { ProjectsService, Project, State } from './projects.service';

@Component({
    selector: 'project.index',
    templateUrl: './projects.index.component.html',
    providers: [ProjectsService]
})
export class ProjectsIndexComponent implements OnInit {
    private projects: Project[];

    private filteredProjects: Project[];
    private filterState: string;
    private state = State;

    constructor(
        private procectsService: ProjectsService
    ) { }

    getProjects(): void {
        this.procectsService.get().subscribe(data => {
            this.projects = data;
            this.filteredProjects = data;
        });
    }

    filterProjects(): void {
        if (this.filterState == null)
            return;

        this.filteredProjects = this.projects.filter(p => p.state == State[this.filterState]);
    }
    resetFilter(): void {
        this.filterState = null;
        this.filteredProjects = this.projects.map(p => p);
    }

    stateName(stateId: number): string {
        return this.state[stateId];
    }

    states(): Array<string> {
        var keys = Object.keys(this.state);
        return keys.slice(keys.length / 2);
    }

    ngOnInit(): void {
        this.getProjects();
    }
}