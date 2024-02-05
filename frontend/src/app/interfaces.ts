interface User {
  id: number;
  name: string;
  label?: string;
  email?: string;
  phone?: string;
  location?: string;
  website?: string;
  summary?: string;
  skills?: Skill[];
  languages?: Language[];
  socials?: Social[];
  works?: Work[];
  educations?: Education[];
  projects?: Project[];
  certifications?: Certification[];
}

interface Certification {
  id: number;
  userId: number;
  name: string;
  authority?: string;
  description?: string;
  licenseNumber?: string;
  url?: string;
  date: Date;
  expirationDate?: Date;
}

interface Education {
  id: number;
  userId: number;
  institution: string;
  area: string;
  studyType: string;
  gpa?: number;
  startDate: Date;
  endDate?: Date;
}

interface Language {
  id: number;
  userId: number;
  name: string;
  proficiency: string;
}

interface Project {
  id: number;
  userId: number;
  name: string;
  description?: string;
  url?: string;
  startDate: Date;
  endDate?: Date;
}

interface Skill {
  id: number;
  userId: number;
  name: string;
}

interface Social {
  id: number;
  userId: number;
  name: string;
  url: string;
}

interface Work {
  id: number;
  userId: number;
  company: string;
  position: string;
  description?: string;
  location?: string;
  startDate: Date;
  endDate?: Date;
}

export { User, Certification, Education, Language, Project, Skill, Social, Work };
