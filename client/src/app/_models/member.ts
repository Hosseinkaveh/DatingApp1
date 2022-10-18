import { photo } from "./photo";

    export interface member {
        userName: string;
        age: number;
        photoUrl: string;
        knownAs: string;
        created: Date;
        lastActive: Date;
        gender: string;
        introduction: string;
        lookingFor: string;
        interests: string;
        city: string;
        country: string;
        photos: photo[];
    }

