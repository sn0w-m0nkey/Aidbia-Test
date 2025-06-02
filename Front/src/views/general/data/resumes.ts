export interface Experience {
    CompanyName: string
    Position: string
    StartDate: string
    EndDate: string | null
    Description: string
    Website: string
}

export interface Education {
    Institution: string
    Qualification: string
    StartDate: string
    EndDate: string
}

export interface Skill {
    Name: string
}

export interface Interest {
    Name: string
}

export interface Resume {
    Id: number
    FullName: string
    Email: string
    PhoneNumber: string
    Summary: string
    Description: string
    IsActive: boolean
    Experiences: Experience[]
    Educations: Education[]
    Skills: Skill[]
    Interests: Interest[]
}

export const resumes: Resume[] = [
    {
        Id: 1,
        FullName: 'Owen M',
        Email: 'owen@gmail.com',
        PhoneNumber: '07123 456 789',
        Summary: 'Full Stack Developer with 5+ years of experience.',
        Description: 'Looking for remote backend roles.',
        IsActive: true,
        Experiences: [
            {
                CompanyName: 'Kainos',
                Position: 'Software Engineer',
                StartDate: '2021-08-16T00:00:00',
                EndDate: null,
                Description: 'Worked on lots of government projects.',
                Website: 'https://kainos.com'
            },
            {
                CompanyName: 'Mr Lender',
                Position: 'Senior Developer',
                StartDate: '2015-01-01T00:00:00',
                EndDate: '2020-10-26T00:00:00',
                Description: 'Ripped people off with high interest loans.',
                Website: 'https://mrlender.com'
            }
        ],
        Educations: [
            {
                Institution: 'NZ University',
                Qualification: 'B.Sc. in Computer Science',
                StartDate: '2015-09-01T00:00:00',
                EndDate: '2019-06-30T00:00:00'
            },
            {
                Institution: 'Microsoft',
                Qualification: 'AZ-900: Microsoft Azure Fundamentals',
                StartDate: '2023-09-01T00:00:00',
                EndDate: '2022-03-30T00:00:00'
            }
        ],
        Skills: [
            { Name: 'C#' },
            { Name: '.NET Core' },
            { Name: 'Vue' }
        ],
        Interests: [
            { Name: 'Muay Thai' },
            { Name: 'Diving' }
        ]
    },
    {
        Id: 2,
        FullName: 'Jane Doe',
        Email: 'jane.doe@example.com',
        PhoneNumber: '07234 567 890',
        Summary: 'Frontend Developer with a passion for UI/UX.',
        Description: 'Open to contract opportunities.',
        IsActive: true,
        Experiences: [
            {
                CompanyName: 'Some Company',
                Position: 'Frontend Engineer',
                StartDate: '2012-05-01T00:00:00',
                EndDate: '2024-08-31T00:00:00',
                Description: 'Developed lots of web applications.',
                Website: 'https://somecompany.com'
            }
        ],
        Educations: [
            {
                Institution: 'Some other University',
                Qualification: 'B.Sc. in Information Technology',
                StartDate: '2014-09-01T00:00:00',
                EndDate: '2018-06-30T00:00:00'
            }
        ],
        Skills: [
            { Name: 'VB' },
            { Name: '.NET' },
            { Name: 'Blazor' }
        ],
        Interests: [
            { Name: 'Traveling' },
            { Name: 'Reading' }
        ]
    }
]
