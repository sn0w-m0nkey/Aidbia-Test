# Homework Assignment

Thank you for your interest in applying for a developer position at Aibidia.

## Scenario

> We at Aibidia just launched our recent solution, Careers application, which allows users to submit CVs to us in a very clear and fun way.
> Unfortunately marketing already launched the solution, so it's your task to add some "key features" to it.

The code feels quite similar to our current technology stack, so it is also a chance for you to gain familiarity with our structure.

## Assignment F: (for applicants in frontend or fullstack positions)

Your homework is to use a VueRouter endpoint ```resume/all``` and implement your (fictional or actual) resume (CV) as you see fit. The data being returned from the API is very simple at the moment. You can either mock the response on UI side (if you are only working with the front end part) or add more meaningful data to your API (if you are applying for a fullstack position).

We pay attention to the following things:

1. How well you adjust your coding style to match ours.
2. What components you create and how they are created.
3. We look at the quality of your comments and typescripted components.
4. Looks are secondary to good DOM structure and clean CSS code.
5. Write at least one test case, so that all test cases pass.
6. If you can't complete the task, that is fine. In this case document your work and how you would continue.

Average time of completion of this homework should not exceed 2h.

## Assignment B: (for applications in backend or fullstack positions)

Front-end developer is trying to use endpoint `HTTP GET resume/all` to get list of resumes from API. The response is returning very simple mock data at moment, because we have no db connection set up.

**Task:** Your task is to fix the API endpoint by working mainly on the design of the application and data access layers, and return a proper set of resumes stored in SQL database.

You may want to setup local SQLServer to host database with appropriate Resumes-table, and include some dummy data for demonstration purposes.

We pay attention to the following things:

1. How you structure your solution
2. What classes you create and how they are created.
3. We look at the quality of your comments.
4. Looks are secondary to good DOM structure and understandable code.
5. SQL script to insert data into SQLServer.
6. If you can't complete the task, that is fine. In this case document your work and how you would continue.

Average time of completion of this homework should not exceed 2h.

## Once you have finished the tasks (both backend end and/or front end as appropriate)

We would like to hear your opinion on:
- Implementing authentication
- Implementing tests
- Solution architecture
- How this would be deployed/maintained
- Improving any part of the solution

You do not have to do any of these, but you should prepare some notes.

## How to install & run

Actually we trust you to be familiar already with our toolset.

## Things you might want to know

### Front

Make a `Front\env.ts` out of `Front\env.example.ts` personal config for the API directory:

Use with localhost server, for example

``` javascript
api = {
    solution: 'http://localhost:7013/api',
};
```

- Default UI port is 8080.
- `Front\src\store\modules\resume-store.ts` contains VueX store
- `Front\src\lib\api\endpoints\hm\createResumeEndpoint.ts` contains Resume endpoint calling.
- `Front\src\types\Resume.ts` contains Resume Typescript typings.

### Back

- Default API port is 7013.
- `Back\src\Aibidia.Homework.API\Controllers\ResumesController.cs` API controller for the resumes endpoint.
- `Back\src\Aibidia.Homework.Application\Resumes\DtosResumeDto.cs` Resume DTO that front expects.
- `Back\src\Aibidia.Homework.Domain\Models\Resume.cs` Resume DBModel.

## Other

You are permitted to use any tools at your disposal to complete the assignment, but be prepared to explain and/or defend any and all additions or modifications you make as part of your submission in a follow-up interview.

Please include feedback on the code structure / style. What you would do differently and why, as we are constantly willing to evolve, and expect the same from you.

## Returning of the assignment

Return the assignment code with your changes in ZIP folder in the same email thread in which you received the code from the recruiter.

**Please make sure you don't zip or send any NuGet / NPM packages.**
