import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class ProjectsService {
    constructor(
        private http: Http,
        @Inject('ORIGIN_URL') private originUrl: string
    ) { }

    get() {
        return this.http.get(this.originUrl + '/api/Projects', { withCredentials: true }).map(data => 
            data.json() as Project[]
        )
    }

    getById(id: number) {
        return this.http.get(this.originUrl + '/api/Projects/' + id, { withCredentials: true }).map(data =>
            data.json() as Project
        )
    }

    add(data: CreateProjectDto) {
        return this.http.post(this.originUrl + '/api/Projects', data, { withCredentials: true });
    }

    update(data: EditProjectDto) {
        return this.http.put(this.originUrl + '/api/Projects/' + data.id, data, { withCredentials: true });
    }
}

export class CreateProjectDto {
    constructor(
        public name: string,
        public location: GeoLocationDto,
        public profit: number
    ) { }
}

export class EditProjectDto {
    constructor(
        public id: number,
        public name: string,
        public location: GeoLocationDto,
        public profit: number
    ) { }
}

export class GeoLocationDto {
    constructor(
        public latitude: number,
        public longitude: number,
        public cityName: string
    ) { }
}

export interface Project {
    id: number,
    name: string,
    created: Date,
    state: State,
    creator: string,
    location: GeoLocation,
    profit: number,
}

export interface GeoLocation {
    latitude: number,
    longitude: number,
    cityName: string,
}

export enum State {
    Lead,
    Contracted,
    UnderConstruction,
    Finished,

    Rejected,
    Cancelled,
}