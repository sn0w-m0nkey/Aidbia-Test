<template>
    <div class="space-y-4 resume-detail">
        <div>
            <h3 class="font-bold">Description</h3>
            <p>{{ resume.Description }}</p>
        </div>

        <div>
            <h3 class="font-bold">Experiences</h3>
            <ul class="list-disc ml-5">
                <li v-for="exp in resume.Experiences" :key="exp.StartDate">
                    <strong>{{ exp.Position }}</strong> at
                    <a :href="exp.Website" target="_blank" class="text-blue-500 underline">{{ exp.CompanyName }}</a>
                    <div>
                        {{ formatDate(exp.StartDate) }} -
                        {{ exp.EndDate ? formatDate(exp.EndDate) : 'Present' }}
                    </div>
                    <div>{{ exp.Description }}</div>
                </li>
            </ul>
        </div>

        <div>
            <h3 class="font-bold">Education</h3>
            <ul class="list-disc ml-5">
                <li v-for="edu in resume.Educations" :key="edu.Qualification">
                    <strong>{{ edu.Qualification }}</strong> at {{ edu.Institution }}
                    ({{ formatDate(edu.StartDate) }} - {{ formatDate(edu.EndDate) }})
                </li>
            </ul>
        </div>

        <div>
            <h3 class="font-bold">Skills</h3>
            <p>{{ resume.Skills.map(s => s.Name).join(', ') }}</p>
        </div>

        <div>
            <h3 class="font-bold">Interests</h3>
            <p>{{ resume.Interests.map(i => i.Name).join(', ') }}</p>
        </div>
    </div>
</template>

<script setup>

const props = defineProps({
    resume: Object
})

function formatDate(dateStr) {
    return new Date(dateStr).toLocaleDateString()
}
</script>

<style scoped>
.resume-detail {
    padding: 1rem;
    border-left: 4px solid #005bbb;
    background-color: #f9f9f9;
    border-radius: 8px;
    font-family: 'Segoe UI', Roboto, sans-serif;
    color: #333;
}

.resume-detail h3 {
    margin-top: 1.5rem;
    margin-bottom: 0.5rem;
    color: #005bbb;
    font-size: 1.2rem;
    border-bottom: 1px solid #ccc;
    padding-bottom: 4px;
}

.resume-detail ul {
    list-style-type: none;
    padding-left: 0;
}

.resume-detail li {
    margin-bottom: 1rem;
    padding-left: 1rem;
    border-left: 3px solid #ddd;
}

.resume-detail li strong {
    display: block;
    font-size: 1rem;
    margin-bottom: 0.2rem;
}

.resume-detail a {
    color: #005bbb;
    text-decoration: underline;
    font-size: 0.9rem;
}

.badge {
    display: inline-block;
    background: #005bbb;
    color: white;
    padding: 4px 10px;
    margin: 0 6px 6px 0;
    font-size: 0.8rem;
    border-radius: 12px;
}
</style>
